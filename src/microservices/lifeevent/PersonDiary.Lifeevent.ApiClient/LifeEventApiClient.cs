using System.Threading.Tasks;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Person.Dto;

namespace PersonDiary.Lifeevent.ApiClient
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
            return settingsRepository.Get(SettingKeys.PersonsServiceUrl);
        }
        public Task GetLifeEvent(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task GetLifeEvents(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> SaveOrUpdate(GateWayUpdateLifeEventDto gateWayUpdateLifeEventDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}