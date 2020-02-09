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

        private const string ConsulSetPersonsKeyUrl = "PDdev/Persons/url";
        private const string ConsulSetPersonsKeyValue = "http://localhost:49442";

        private const string ConsulSetLifeeventsKeyUrl = "PDdev/Lifeevents/url";
        private const string ConsulSetLifeeventsKeyValue = "http://localhost:65354";
        
        private const string ConsulSetLifeEventConnectionStringUrl = "PDdev/Lifeevents/ConnectionString";
        private const string ConsulSetLifeEventConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=LifeEvents;Integrated Security=True";
        
        private const string ConsulSetPersonsConnectionStringUrl = "PDdev/Persons/ConnectionString";
        private const string ConsulSetPersonsConnectionStringValue = "Data Source=(local)\\sql2016;Initial Catalog=Persons;Integrated Security=True";
        
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
            return PutAsync($"{ConsulSetPersonsKeyUrl}", ConsulSetPersonsKeyValue);
        }

        public Task SetLifeEventsServiceUrlValueAsync()
        {
            return PutAsync($"{ConsulSetLifeeventsKeyUrl}", ConsulSetLifeeventsKeyValue);
        }
       
        public Task<string> GetPersonsServiceUrlValueAsync()
        { 
            return GetAsync<string>($"{ConsulSetPersonsKeyUrl}?raw");
        }

        public Task<string> GetLifeEventsServiceUrlValueAsync()
        {
            return GetAsync<string>($"{ConsulSetLifeeventsKeyUrl}?raw");
        }
        
        public Task SetPersonServiceConnectionStringAsync()
        {
            return PutAsync($"{ConsulSetPersonsConnectionStringUrl}", ConsulSetPersonsConnectionStringValue);
        }
        public Task SetLifeEventServiceConnectionStringAsync()
        {
            return PutAsync($"{ConsulSetLifeEventConnectionStringUrl}", ConsulSetLifeEventConnectionStringValue);
        }
        
        public Task<string> GetLifeEventsServiceConnectionStringAsync()
        {
            return GetAsync<string>($"{ConsulSetLifeEventConnectionStringUrl}?raw");
        }
        
        public Task<string> GetPersonsServiceConnectionStringAsync()
        {
            return GetAsync<string>($"{ConsulSetPersonsConnectionStringUrl}?raw");
        }
    }
}

//http://localhost:8500/v1/kv/PDdev/Persons/url
//http://localhost:8500/v1/kv/PDdev/Persons/url?raw