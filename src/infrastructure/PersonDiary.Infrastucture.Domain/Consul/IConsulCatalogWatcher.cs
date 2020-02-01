using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.Consul
{
    public interface IConsulCatalogWatcher
    {
        Task CheckSettingsAsync(Action<IReadOnlyDictionary<string,string>> onChange);
    }
}
