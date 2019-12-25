using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public interface IConsulApiClient
    {
        Task SetPersonsValueAsync();

        Task SetLifeeventsValueAsync();

        Task<string> GetPersonsValueAsync();

        Task<string> GetLifeeventsValueAsync();
    }
}
