using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using System;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public class ConsulApiClient : BaseApiClient, IConsulApiClient
    {
        private const string ConsulEndpointUrl = "http://localhost:8500/v1/kv/";

        private const string ConsulPersonsKeyUrl = "PDdev/Persons/url";
        private const string ConsulSetPersonsKeyValue = "http://localhost:49442";

        private const string ConsulLifeeventsKeyUrl = "PDdev/Lifeevents/url";
        private const string ConsulLifeeventsKeyValue = "http://localhost:65354";
        
        private const string ConsulLifeEventConnectionStringUrl = "PDdev/Lifeevents/ConnectionString";
        private const string ConsulLifeEventConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=LifeEvents;Integrated Security=True";
        
        private const string ConsulPersonsConnectionStringUrl = "PDdev/Persons/ConnectionString";
        private const string ConsulPersonsConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=Persons;Integrated Security=True";
        
        private const string ConsulPersonEventBusConnectionStringUrl = "PDdev/Persons/EventBusConnectionString";
        private const string ConsulPersonEventBusConnectionStringValue = "host=localhost";
        
        public ConsulApiClient
        (
            IHttpRequestExecutor httpRequestExecutor,
            IUriCreator uriCreator,
            IResponseParser responseParser
        )
            : base(httpRequestExecutor, uriCreator, responseParser)
        {
        }

        protected override string GetApiEndpoint() 
        {
            return ConsulEndpointUrl;
        }

        public Task SetPersonsServiceUrlValueAsync()
        {
            return PutAsync($"{ConsulPersonsKeyUrl}", ConsulSetPersonsKeyValue);
        }

        public Task SetLifeEventsServiceUrlValueAsync()
        {
            return PutAsync($"{ConsulLifeeventsKeyUrl}", ConsulLifeeventsKeyValue);
        }
       
        public Task<string> GetPersonsServiceUrlValueAsync()
        { 
            return GetAsync<string>($"{ConsulPersonsKeyUrl}?raw");
        }

        public Task<string> GetLifeEventsServiceUrlValueAsync()
        {
            return GetAsync<string>($"{ConsulLifeeventsKeyUrl}?raw");
        }
        
        public Task SetPersonServiceConnectionStringAsync()
        {
            return PutAsync($"{ConsulPersonsConnectionStringUrl}", ConsulPersonsConnectionStringValue);
        }
        public Task SetLifeEventServiceConnectionStringAsync()
        {
            return PutAsync($"{ConsulLifeEventConnectionStringUrl}", ConsulLifeEventConnectionStringValue);
        }
        
        public Task<string> GetLifeEventsServiceConnectionStringAsync()
        {
            return GetAsync<string>($"{ConsulLifeEventConnectionStringUrl}?raw");
        }
        
        public Task<string> GetPersonsServiceConnectionStringAsync()
        {
            return GetAsync<string>($"{ConsulPersonsConnectionStringUrl}?raw");
        }

        public Task SetPersonEventBusConnectionStringAsync()
        {
            return PutAsync($"{ConsulPersonEventBusConnectionStringUrl}", ConsulPersonEventBusConnectionStringValue);
        }

        public Task<string> GetPersonEventBusConnectionStringAsync()
        {
            return GetAsync<string>($"{ConsulPersonEventBusConnectionStringUrl}?raw");
        }
    }
}

//http://localhost:8500/v1/kv/PDdev/Persons/url
//http://localhost:8500/v1/kv/PDdev/Persons/url?raw