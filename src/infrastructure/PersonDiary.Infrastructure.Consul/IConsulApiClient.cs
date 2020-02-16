using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public interface IConsulApiClient
    {
        Task SetPersonsServiceUrlValueAsync();
        
        Task<string> GetPersonsServiceUrlValueAsync();
        
        Task SetLifeEventsServiceUrlValueAsync();

        Task<string> GetLifeEventsServiceUrlValueAsync();
        
        Task SetPersonServiceConnectionStringAsync();
        
        Task<string> GetPersonsServiceConnectionStringAsync();
        
        Task SetLifeEventServiceConnectionStringAsync();
        
        Task<string> GetLifeEventsServiceConnectionStringAsync();
        
        Task SetPersonEventBusConnectionStringAsync();
        
        Task<string> GetPersonEventBusConnectionStringAsync();
    }
}
