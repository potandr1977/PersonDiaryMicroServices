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
        private const string ConsulLifeeventsKeyUrl = "PDdev/Lifeevents/url";
        private const string ConsulLifeEventConnectionStringUrl = "PDdev/Lifeevents/ConnectionString";
        private const string ConsulPersonsConnectionStringUrl = "PDdev/Persons/ConnectionString";
        private const string ConsulPersonEventBusConnectionStringUrl = "PDdev/Persons/EventBusConnectionString";
        
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

        public Task SetPersonsServiceUrlValueAsync(string ConsulSetPersonsKeyValue)
        {
            return PutAsync($"{ConsulPersonsKeyUrl}", ConsulSetPersonsKeyValue);
        }

        public Task SetLifeEventsServiceUrlValueAsync(string ConsulLifeeventsKeyValue)
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
        
        public Task SetPersonServiceConnectionStringAsync(string ConsulPersonsConnectionStringValue)
        {
            return PutAsync($"{ConsulPersonsConnectionStringUrl}", ConsulPersonsConnectionStringValue);
        }
        public Task SetLifeEventServiceConnectionStringAsync(string ConsulLifeEventConnectionStringValue)
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

        public Task SetPersonEventBusConnectionStringAsync(string ConsulPersonEventBusConnectionStringValue)
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