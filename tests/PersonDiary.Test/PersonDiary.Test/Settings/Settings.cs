using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;

namespace PersonDiary.Test.Settings
{
    public class Tests
    {
        private ISettingsRepository settingsRepository;
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
                .AddSingleton<IConsulCatalogWatcher, ConsulCatalogWatcher>()
                .AddSingleton<ISettingsRepository, SettingsRepository>()
                .BuildServiceProvider();
           
            consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            consulCatalogWatcher = serviceProvider.GetService<IConsulCatalogWatcher>();
            //settingsRepository = serviceProvider.GetService<SettingsRepository>();
        }
        [Test]
        public async Task GetConsulValue()
        {
            var personUrl= await consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = await consulApiClient.GetLifeEventsServiceUrlValueAsync();
            
            Assert.IsTrue(personUrl == "http://localhost:49442" && lifeEventUrl=="http://localhost:65354");
        }
        [Test]
        public async Task CheckSettingsAsync()
        {
            await consulCatalogWatcher.CheckSettingsAsync((settings) =>
            {
                var l = settings.FirstOrDefault(p => p.Key == ConsulSettingKeys.LifeEventsServiceUrl).Value;
                var pkv = settings.FirstOrDefault(p => p.Key == ConsulSettingKeys.PersonsServiceUrl).Value;
            });
            Assert.Pass();
        }

        [Test]
        public void CheckSettingsRepositoryAsync()
        {  
            var settingsRepository = new SettingsRepository(consulCatalogWatcher);
            settingsRepository.Initialize();
            var personUrl = settingsRepository.Get(ConsulSettingKeys.PersonsServiceUrl);
            var lifeEventUrl = settingsRepository.Get(ConsulSettingKeys.LifeEventsServiceUrl);
            Assert.Pass();
        }
    }
}