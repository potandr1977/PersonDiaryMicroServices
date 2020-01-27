using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;

namespace PersonDiary.Test
{
    public class Tests
    {
        [SetUp]
        public async void Setup()
        {
            var serviceProvider = new ServiceCollection()
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
            var personUrl= consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = consulApiClient.GetLifeEventsServiceUrlValueAsync();
            
        }

        [Test]
        public void OnSettingsChange()
        {
            Assert.Pass();
        }
    }
}