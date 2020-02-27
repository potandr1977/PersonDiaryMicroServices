using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public interface IConsulApiClient
    {
        Task SetPersonsServiceUrlValueAsync(string ConsulSetPersonsKeyValue);

        Task SetLifeEventsServiceUrlValueAsync(string ConsulLifeeventsKeyValue);

        Task<string> GetPersonsServiceUrlValueAsync();

        Task<string> GetLifeEventsServiceUrlValueAsync();

        Task SetPersonServiceConnectionStringAsync(string ConsulPersonsConnectionStringValue);

        Task SetLifeEventServiceConnectionStringAsync(string ConsulLifeEventConnectionStringValue);

        Task<string> GetLifeEventsServiceConnectionStringAsync();


        Task<string> GetPersonsServiceConnectionStringAsync();

        Task SetPersonEventBusConnectionStringAsync(string ConsulPersonEventBusConnectionStringValue);

        Task<string> GetPersonEventBusConnectionStringAsync();
    }
}
