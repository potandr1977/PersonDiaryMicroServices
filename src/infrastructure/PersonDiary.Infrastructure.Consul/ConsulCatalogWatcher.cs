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

        private const int InfiniteTimeout = 10;//seconds
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
            var cancellationToken = cts.Token;
            var tcsInitiated = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            lock (catalogLockObj)
            {
                try
                {
                    CheckDisposed();

                    watchCatalogLoopTaskList.Add(Task.Factory.StartNew(async () =>
                    {
                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            try
                            {
                                var lifeEventsServiceUrlValue = await consulApiClient.GetLifeEventsServiceUrlValueAsync();
                                var personsServiceUrlValue = await consulApiClient.GetPersonsServiceUrlValueAsync();
                                
                                var dictionary = new Dictionary<string,string>()
                                {
                                    {"lifeEventsServiceUrl",lifeEventsServiceUrlValue},
                                    {"personsServiceUrl",personsServiceUrlValue},
                                };
                                
                                onChange(dictionary);
                                tcsInitiated.TrySetResult(true);
                            }
                            catch
                            {
                                //ignore
                            }

                            await Task.Delay(TimeSpan.FromSeconds(InfiniteTimeout)).ConfigureAwait(false);
                        }

                        tcsInitiated.TrySetResult(true);

                    }, TaskCreationOptions.LongRunning).Unwrap());
                }
                catch (ObjectDisposedException)
                {
                    tcsInitiated.TrySetCanceled();
                }
            }

            return tcsInitiated.Task;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*
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
        */

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

