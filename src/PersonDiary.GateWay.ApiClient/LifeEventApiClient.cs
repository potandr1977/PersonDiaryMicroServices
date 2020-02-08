using System.Threading.Tasks;
using PersonDiary.GateWay.Dto;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;

namespace PersonDiary.GateWay.ApiClient
{
    public class LifeEventApiClient : BaseApiClient, ILifeEventApiClient
    {
        private readonly ISettingsRepository settingsRepository;
        
        public LifeEventApiClient
        (
            IHttpRequestExecutor httpRequestExecutor,
            IUriCreator uriCreator,
            IResponseParser responseParser,
            ISettingsRepository settingsRepository
        )
            : base(httpRequestExecutor, uriCreator, responseParser)
        {
            this.settingsRepository = settingsRepository;
        }
        protected override string GetApiEndpoint() 
        {
            return settingsRepository.Get(ConsulSettingKeys.PersonsServiceUrl);
        }
        public Task GetLifeEvent(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task GetLifeEvents(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> SaveOrUpdate(GateWayUpdateLifeEventDto lifeEvent)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}