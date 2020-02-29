using System;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.Settings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.Cache;

namespace PersonDiary.Infractructure.Settings
{
    public class SettingsRepository : ISettingsRepository
    {
        private IReadOnlyCollection<KeyValuePair<string,string>> settings;
        private readonly ICacheStore cacheStore;
        
        public SettingsRepository(ICacheStore cacheStore)
        {
            this.cacheStore = cacheStore;
            var settingsSerialized = cacheStore.GetValue(SettingKeys.RedisSettingsKey);
            settings = JsonConvert.DeserializeObject<IReadOnlyCollection<KeyValuePair<string, string>>>(settingsSerialized);
        }

        public virtual string Get(string name)
        {
            return settings.FirstOrDefault(p=>p.Key==name).Value;
        }

    }
}
