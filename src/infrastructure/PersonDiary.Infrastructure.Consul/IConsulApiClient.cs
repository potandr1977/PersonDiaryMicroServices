using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public interface IConsulApiClient
    {
        Task SetPersonsServiceUrlValueAsync();

        Task SetLifeEventsServiceUrlValueAsync();

        Task<string> GetPersonsServiceUrlValueAsync();

        Task<string> GetLifeEventsServiceUrlValueAsync();
    }
}
