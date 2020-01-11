using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.Consul;
using PersonDiary.Infrastructure.Domain.Settings;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonDiary.Infractructure.Settings
{
    public class SettingsRepository : ISettingsRepository
    {
        private IReadOnlyDictionary<string, string> settings;
        private readonly IConsulCatalogWatcher consulCatalogWatcher;
        private readonly IHostingEnvironment hostingEnvironment;

        public SettingsRepository(IConsulCatalogWatcher consulCatalogWatcher, IHostingEnvironment hostingEnvironment)
        {
            this.consulCatalogWatcher = consulCatalogWatcher;
            this.hostingEnvironment = hostingEnvironment;

            this.consulCatalogWatcher.CheckOptionsAsync(OnSettingsChange);
        }

        public Task<string> Get(string name)
        {
            return Task.FromResult(settings[name]);
        }

        private void OnSettingsChange(IReadOnlyCollection<KeyValuePair<string, string>> settings)
        {
            var settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string,string>>(
                File.ReadAllText($"{hostingEnvironment.ContentRootPath}\\movie.json"));

        }
    }
}
