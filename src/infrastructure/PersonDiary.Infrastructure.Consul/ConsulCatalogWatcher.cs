using PersonDiary.Infrastructure.Domain.Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public class ConsulCatalogWatcher : IConsulCatalogWatcher, IDisposable
    {

        private static readonly TimeSpan InfiniteTimeout = TimeSpan.FromMilliseconds(-1.0);

        private bool disposed;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private readonly object catalogLockObj = new object();
        private readonly List<Task> watchCatalogLoopTaskList = new List<Task>();
        private readonly IConsulApiClient consulApiClient;

        public ConsulCatalogWatcher(IConsulApiClient consulApiClient)
        {
            this.consulApiClient = consulApiClient;   
        }

        public Task CheckOptionsAsync(Action<IReadOnlyCollection<KeyValuePair<string, string>>> onChange)
        {
            keyPath = FormValidKey(keyPath);
            var cancellationToken = cts.Token;
            var tcsInited = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            lock (catalogLockObj)
            {
                try
                {
                    CheckDisposed();

                    watchCatalogLoopTaskList.Add(Task.Factory.StartNew(async () =>
                    {
                        long currentIndex = 0;

                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            try
                            {
                                var url =
                                    $"http://{consulServiceAddress.Address}:{consulServiceAddress.Port}/v1/kv/{keyPath}?recurse&wait=10s&index={currentIndex}";

                                using (var response = await httpClient.GetAsync(url).ConfigureAwait(false))
                                {
                                    var index = TryGetConsulIndex(response);

                                    if ((response.IsSuccessStatusCode == false && response.StatusCode != HttpStatusCode.NotFound) || currentIndex == index)
                                    {
                                        continue;
                                    }

                                    currentIndex = index;
                                    var dictionary = await BuildCollectionAsync(keyPath, response).ConfigureAwait(false);
                                    onChange(dictionary);
                                    tcsInited.TrySetResult(true);
                                }
                            }
                            catch
                            {
                                //ignore
                            }

                            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                        }

                        tcsInited.TrySetResult(true);

                    }, TaskCreationOptions.LongRunning).Unwrap());
                }
                catch (ObjectDisposedException)
                {
                    tcsInited.TrySetCanceled();
                }
            }

            return tcsInited.Task;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static async Task<IReadOnlyCollection<KeyValuePair<string, string>>> BuildCollectionAsync(string keyPath, HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            var kvs = await ReadKeysAsync(response).ConfigureAwait(false);

            if (kvs == null || kvs.Length == 0)
            {
                return null;
            }

            var collection = new List<KeyValuePair<string, string>>(kvs.Length);

            for (var index = 0; index < kvs.Length; index++)
            {
                var kv = kvs[index];
                var key = kv.Key.Substring(keyPath.Length).Replace(ConsulPath[0], CorePath);
                var value = kv.Value == null ? null : Encoding.UTF8.GetString(Convert.FromBase64String(kv.Value));
                collection.Add(new KeyValuePair<string, string>(key, value));
            }

            return collection;
        }

        private static async Task<KeyValue[]> ReadKeysAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var kvs =  tent.FromJsonString<KeyValue[]>();

            return kvs;
        }

        private static long TryGetConsulIndex(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("X-Consul-Index", out var headerValues) == false)
            {
                return 0;
            }

            var headerValue = headerValues.FirstOrDefault();

            if (headerValue == null)
            {
                return 0;
            }

            if (long.TryParse(headerValue, out var index) == false)
            {
                return 0;
            }

            return index;
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            lock (catalogLockObj)
            {
                if (disposing)
                {
                    if (cts != null)
                    {
                        cts.Cancel();
                        Task.WaitAll(watchCatalogLoopTaskList.ToArray());
                        cts.Dispose();
                    }
                    
                }

                disposed = true;
            }
        }

        private void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(ConsulCatalogWatcher));
            }
        }

        ~ConsulCatalogWatcher()
        {
            Dispose(false);
        }

        private class KeyValue
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}

