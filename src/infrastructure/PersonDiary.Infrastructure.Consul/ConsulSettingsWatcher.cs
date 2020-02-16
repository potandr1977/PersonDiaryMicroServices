using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastructure.Domain.Consul;

namespace PersonDiary.Infrastructure.Consul
{
    public class ConsulSettingsWatcher : IConsulSettingsWatcher
    {
        private readonly IConsulApiClient consulApiClient;
        private readonly ICacheStore cacheStore;
        public ConsulSettingsWatcher(IConsulApiClient consulApiClient,ICacheStore cacheStore)
        {
            this.consulApiClient = consulApiClient;
            this.cacheStore = cacheStore;
        }

        public async Task CheckSettingsAsync(Action<IReadOnlyCollection<KeyValuePair<string,string>>> onChange = null)
        {
            var personUrl= await consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = await consulApiClient.GetLifeEventsServiceUrlValueAsync();
            var personConnectionString = await consulApiClient.GetPersonsServiceConnectionStringAsync();
            var lifeEventConnectionString = await consulApiClient.GetLifeEventsServiceConnectionStringAsync();
            var eventBusConnectionPersonString = await consulApiClient.GetPersonEventBusConnectionStringAsync();

            var settings = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(SettingKeys.PersonsServiceUrl, personUrl),
                new KeyValuePair<string, string>(SettingKeys.LifeEventsServiceUrl, lifeEventUrl),
                new KeyValuePair<string, string>(SettingKeys.ConnectionStringPerson, personConnectionString),
                new KeyValuePair<string, string>(SettingKeys.ConnectionStringLifeEvent, lifeEventConnectionString),
                new KeyValuePair<string, string>(SettingKeys.EventBusConnectionStringPerson, eventBusConnectionPersonString)
            };

            var settingsSerialized = JsonConvert.SerializeObject(settings);
            cacheStore.SetValue(SettingKeys.RedisSettingsKey, settingsSerialized);
            
            onChange?.Invoke(settings);
        }
    }
}