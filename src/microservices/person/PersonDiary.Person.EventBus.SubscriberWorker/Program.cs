using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Person.ApiClient;
using PersonDiary.Person.Domain.EventBus;
using PersonDiary.Person.EventBus;

namespace PersonDiary.Person.EventBus.SubscriberWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDbExecutorRedis, DbExecutorRedis>();
                    services.AddSingleton<ICacheStore, CacheStore>();
                    services.AddSingleton<ISettingsRepository, SettingsRepository>();
                    services.AddSingleton<IUriCreator, UriCreator>();
                    services.AddSingleton<IResponseParser, ResponseParser>();  
                    services.AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>();
                    services.AddSingleton<IPersonApiClient, PersonApiClient>();
                    services.AddSingleton<IPersonSubscriberFactory, PersonSubscriberFactory>();
                    services.AddHostedService<Worker>();
                });
    }
}