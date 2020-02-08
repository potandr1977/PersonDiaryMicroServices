using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain.Consul;

namespace PersonDiary.Infrastructure.Consul
{
    public class ConsulCatalogWatcher : IConsulCatalogWatcher
    {
        private readonly IConsulApiClient consulApiClient;
        public ConsulCatalogWatcher(IConsulApiClient consulApiClient)
        {
            this.consulApiClient = consulApiClient;
        }

        public async Task CheckSettingsAsync(Action<IReadOnlyCollection<KeyValuePair<string,string>>> onChange)
        {
            var personUrl= await consulApiClient.GetPersonsServiceUrlValueAsync();
            var lifeEventUrl = await consulApiClient.GetLifeEventsServiceUrlValueAsync();

            var settings = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(ConsulSettingKeys.PersonsServiceUrl, personUrl),
                new KeyValuePair<string, string>(ConsulSettingKeys.LifeEventsServiceUrl, lifeEventUrl)
            };

            onChange(settings);
        }
    }
}