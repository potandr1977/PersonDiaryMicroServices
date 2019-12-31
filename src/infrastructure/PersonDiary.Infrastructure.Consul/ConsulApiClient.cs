using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using System;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Consul
{
    public class ConsulApiClient : BaseApiClient, IConsulApiClient
    {
        private const string CONSUL_ENDPOINT_URL = "http://localhost:8500/v1/kv/";

        private const string CONSUL_SET_PERSONS_KEY_URL = "PDdev/Persons/url";
        private const string CONSUL_SET_PERSONS_KEY_VALUE = "http://localhost:49442";

        private const string CONSUL_SET_LIFEEVENTS_KEY_URL = "PDdev/Lifeevents/url";
        private const string CONSUL_SET_LIFEEVENTS_KEY_VALUE = "http://localhost:65354";
        
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
            return CONSUL_ENDPOINT_URL;
        }

        public Task SetPersonsValueAsync()
        {
            return PutAsync($"{CONSUL_SET_PERSONS_KEY_URL}", CONSUL_SET_PERSONS_KEY_VALUE);
        }

        public Task SetLifeeventsValueAsync()
        {
            return PutAsync($"{CONSUL_SET_LIFEEVENTS_KEY_URL}", CONSUL_SET_LIFEEVENTS_KEY_VALUE);
        }

        public Task<string> GetPersonsValueAsync()
        {
            return GetAsync<string>($"{GetApiEndpoint()}{CONSUL_SET_PERSONS_KEY_URL}");
        }

        public Task<string> GetLifeeventsValueAsync()
        {
            return GetAsync<string>($"{GetApiEndpoint()}{CONSUL_SET_LIFEEVENTS_KEY_URL}");
        }
    }
}

//http://localhost:8500/v1/kv/PDdev/Persons/url
//http://localhost:8500/v1/kv/PDdev/Persons/url?raw