using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PersonDiary.Infractructure.Settings;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.Test.Settings
{
    public class Tests
    {
        private ISettingsRepository settingsRepository;
        private IConsulApiClient consulApiClient;
        private IConsulSettingsWatcher consulSettingsWatcher;
        private ICacheStore cacheStore;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                .AddSingleton<IUriCreator, UriCreator>()
                .AddSingleton<IResponseParser, ResponseParser>()
                .AddSingleton<IConsulApiClient, ConsulApiClient>()
                .AddSingleton<IConsulSettingsWatcher, ConsulSettingsWatcher>()
                .AddSingleton<IDbExecutorRedis, DbExecutorRedis>()
                .AddSingleton<ICacheStore, CacheStore>()
                .AddSingleton<ISettingsRepository, SettingsRepository>()
                .BuildServiceProvider();
           
            consulApiClient = serviceProvider.GetService<IConsulApiClient>();
            consulSettingsWatcher = serviceProvider.GetService<IConsulSettingsWatcher>();
            cacheStore = serviceProvider.GetService<ICacheStore>();
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
            var lkv = default(string);
            var pkv = default(string);
            await consulSettingsWatcher.CheckSettingsAsync((settings) =>
            {
                lkv = settings.FirstOrDefault(p => p.Key == SettingKeys.LifeEventsServiceUrl).Value;
                pkv = settings.FirstOrDefault(p => p.Key == SettingKeys.PersonsServiceUrl).Value;
            });
            Assert.IsTrue(lkv!=null && pkv!=null);
        }

        [Test]
        public void CheckSettingsRepositoryAsync()
        {  
            var settingsRepository = new SettingsRepository(cacheStore);
            var personUrl = settingsRepository.Get(SettingKeys.PersonsServiceUrl);
            var lifeEventUrl = settingsRepository.Get(SettingKeys.LifeEventsServiceUrl);
            
            Assert.IsTrue(!string.IsNullOrEmpty(personUrl) && !string.IsNullOrEmpty(lifeEventUrl));
        }
        
        [Test]
        public void CheckRedisCacheStore()
        {
            var settingsSerialized = "asdfasdf";
            cacheStore.SetValue("test", settingsSerialized);
            var getvalue = cacheStore.GetValue("test");
            Assert.IsTrue(settingsSerialized==getvalue);
        }
    }
}