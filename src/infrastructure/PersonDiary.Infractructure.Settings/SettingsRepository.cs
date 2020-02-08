using System;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.Settings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiary.Infractructure.Settings
{
    public class SettingsRepository : ISettingsRepository
    {
        private IReadOnlyCollection<KeyValuePair<string,string>> settings;
        private readonly IConsulCatalogWatcher consulCatalogWatcher;

        public SettingsRepository(IConsulCatalogWatcher consulCatalogWatcher)
        {
            this.consulCatalogWatcher = consulCatalogWatcher;
        }

        public async void Initialize()
        {
            await consulCatalogWatcher.CheckSettingsAsync(settings=>this.settings = settings);
        }

        public string Get(string name)
        {
            var value = settings.FirstOrDefault().Value;
            if (value == null)
                throw new NullReferenceException();
            
            return settings.FirstOrDefault().Value; 
        }

    }
}
