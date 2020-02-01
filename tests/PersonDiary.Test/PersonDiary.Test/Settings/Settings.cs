using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;

namespace PersonDiary.Test.Settings
{
    public class Tests
    {
        private IConsulApiClient consulApiClient;
        private IConsulCatalogWatcher consulCatalogWatcher;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .BuildServiceProvider();
           
            consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            consulCatalogWatcher = serviceProvider.GetService<IConsulCatalogWatcher>();
        }
        [Test]
        public async Task GetConsulValue()
        {
            var personUrl= await consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = await consulApiClient.GetLifeEventsServiceUrlValueAsync();
            
            Assert.IsTrue(personUrl == "http://localhost:49442" && lifeEventUrl=="http://localhost:65354");
        }
        [Test]
        public void CheckSettingsAsync()
        {
            consulCatalogWatcher.CheckSettingsAsync(OnSettingsChange);
            Assert.Pass();
        }

        private static void OnSettingsChange(IReadOnlyDictionary<string, string> settings)
        {
            var l = settings[ConsulSettingKeys.LifeEventsServiceUrl];
            var p = settings[ConsulSettingKeys.PersonsServiceUrl];
        }
    }
}