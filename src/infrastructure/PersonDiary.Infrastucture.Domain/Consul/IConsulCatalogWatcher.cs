using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.Consul
{
    public interface IConsulCatalogWatcher
    {
        Task CheckSettingsAsync(Action<IReadOnlyCollection<KeyValuePair<string, string>>> onChange);
    }
}
