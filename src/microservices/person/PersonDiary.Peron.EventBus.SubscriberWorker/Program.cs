using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Person.Domain.EventBus;
using PersonDiary.Person.EventBus;

namespace PersonDiary.Peron.EventBus.ConsumerWorker
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
                    services.AddSingleton<IPersonSubscriberFactory, PersonSubscriberFactory>();
                    services.AddHostedService<Worker>();
                });
    }
}