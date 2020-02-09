using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.Consul
{
    public interface IConsulSettingsWatcher
    {
        Task CheckSettingsAsync(Action<IReadOnlyCollection<KeyValuePair<string, string>>> onChange = null);
    }
}
