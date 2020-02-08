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
    }
}

//http://localhost:8500/v1/kv/PDdev/Persons/url
//http://localhost:8500/v1/kv/PDdev/Persons/url?raw