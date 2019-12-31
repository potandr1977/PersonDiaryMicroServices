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
        
        static void Main(string[] args)
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
            var personTask = consulApiClient.SetPersonsValueAsync();
            var lifeeventTask = consulApiClient.SetLifeeventsValueAsync();

            var resultTask =  Task.WhenAll(personTask, lifeeventTask);
            try
            {
                resultTask.Wait();
            }
            catch(Exception ex) 
            { 
                logger.LogTrace(ex.Message); 
            };

            if (personTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Person service registered");

            if (lifeeventTask.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("lifeevent service registered");

            Console.WriteLine("Operation completed");
            Console.ReadLine();
        }
    }
}
