using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using System;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.ConsulKeyValueSetter
{
    class Program
    {
        private const string ConsulSetPersonsKeyValue = "https://localhost:44330";
        private const string ConsulLifeeventsKeyValue = "https://localhost:44378/";
        private const string ConsulLifeEventConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=LifeEvents;Integrated Security=True";
        private const string ConsulPersonsConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=Persons;Integrated Security=True";
        private const string ConsulPersonEventBusConnectionStringValue = "host=localhost";

        private static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IDbExecutorRedis,DbExecutorRedis>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .AddSingleton<ICacheStore,CacheStore>()
                .AddSingleton<IConsulSettingsWatcher,ConsulSettingsWatcher>()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger("Debug");

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            
            var personTask = consulApiClient.SetPersonsServiceUrlValueAsync(ConsulSetPersonsKeyValue);
            var lifeEventTask = consulApiClient.SetLifeEventsServiceUrlValueAsync(ConsulLifeeventsKeyValue);

            var personConnectionStringTask = 
                consulApiClient.SetPersonServiceConnectionStringAsync(ConsulPersonsConnectionStringValue);
            var lifeConnectionStringEventTask = 
                consulApiClient.SetLifeEventServiceConnectionStringAsync(ConsulLifeEventConnectionStringValue);

            var eventBusPersonConnectionStringTask = 
                consulApiClient.SetPersonEventBusConnectionStringAsync(ConsulPersonEventBusConnectionStringValue);

            await Task.WhenAll(
                personTask, 
                lifeEventTask,
                personConnectionStringTask,
                lifeConnectionStringEventTask,
                eventBusPersonConnectionStringTask);

            if (personTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Person service url registered");

            if (lifeEventTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("LifeEvent service url registered");
            
            if (personConnectionStringTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Person service connection string registered");

            if (lifeConnectionStringEventTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("LifeEvent service connection string registered");
            
            if (eventBusPersonConnectionStringTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Person Eventbus connection string registered");

            await serviceProvider
                .GetService<IConsulSettingsWatcher>().CheckSettingsAsync();
            
            Console.WriteLine("Values has been set");
            Console.ReadLine();
        }
    }
}
