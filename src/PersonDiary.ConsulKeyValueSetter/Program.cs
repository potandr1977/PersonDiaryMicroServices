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

namespace PersonDiary.ConsulKeyValueSetter
{
    class Program
    {
        private const string ConsulSetPersonsKeyUrl = "PDdev/Persons/url";
        private const string ConsulSetPersonsKeyValue = "http://localhost:49442";

        private const string ConsulSetLifeEventsKeyUrl = "PDdev/Lifeevents/url";
        private const string ConsulSetLifeEventsKeyValue = "http://localhost:65354";

        private static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger("Debug");

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            var personTask = consulApiClient.SetPersonsServiceUrlValueAsync();
            var lifeEventTask = consulApiClient.SetLifeEventsServiceUrlValueAsync();

            await Task.WhenAll(personTask, lifeEventTask);

            if (personTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Person service url registered");

            if (lifeEventTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("LifeEvent service url registered");

            Console.WriteLine("Values has been set");

            var lifeEventsServiceUrlValueTask = consulApiClient.GetLifeEventsServiceUrlValueAsync();
            var personsServiceUrlValueTask = consulApiClient.GetPersonsServiceUrlValueAsync();
            var rt = await Task.WhenAll(lifeEventsServiceUrlValueTask, personsServiceUrlValueTask);
           
            Console.WriteLine($"lev {lifeEventsServiceUrlValueTask.Result} per {personsServiceUrlValueTask.Result}");
            Console.ReadLine();
        }
    }
}
