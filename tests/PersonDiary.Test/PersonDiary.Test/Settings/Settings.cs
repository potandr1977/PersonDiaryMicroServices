using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;

namespace PersonDiary.Test.Settings
{
    public class Tests
    {
        [SetUp]
        public async Task Setup()
        {
           
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .BuildServiceProvider();

            /*
            serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger("Debug");

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");
            */
            
            var consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            var personUrl= await consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = await consulApiClient.GetLifeEventsServiceUrlValueAsync();
            
        }

        [Test]
        public void OnSettingsChange()
        {
            Assert.Pass();
        }
    }
}