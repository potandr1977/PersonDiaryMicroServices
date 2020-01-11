using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using Microsoft.Extensions.Logging;
using PersonDiary.Infrastructure.Domain.ApiClient;

namespace PersonDiary.Test
{
    public class Tests
    {
        private readonly ServiceProvider serviceProvider;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .BuildServiceProvider();
        }

        [Test]
        public void OnSettingsChange()
        {
            Assert.Pass();
        }
    }
}