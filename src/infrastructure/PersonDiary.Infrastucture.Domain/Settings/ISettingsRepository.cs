using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.Settings
{
    public interface ISettingsRepository
    {
        Task<string> Get(string name);
    }
}
