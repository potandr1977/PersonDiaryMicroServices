using System.Threading.Tasks;
using PersonDiary.Infrastructure.Consul;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.Domain.Settings;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.ApiClient
{
    public class PersonApiClient : BaseApiClient, IPersonApiClient
    {
        private readonly ISettingsRepository settingsRepository;

        public PersonApiClient
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
        
        protected  override string GetApiEndpoint() 
        {
            return settingsRepository.Get(SettingKeys.PersonsServiceUrl);
        }
        
        public Task<GetPersonResponseDto> GetPersonAsync(GetPersonRequestDto getPersonRequestDto)
        {
            return GetAsync<GetPersonResponseDto>($"Person", getPersonRequestDto);
        }

        public Task<GetPersonsResponseDto> GetPersonsAsync(GetPersonsRequestDto getPersonsRequestDto)
        {
           return GetAsync<GetPersonsResponseDto>($"Person", getPersonsRequestDto);
        }

        public Task CreatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto)
        {
            return PostAsync($"Person",updatePersonRequestDto);
        }
        
        public Task UpdatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto)
        {
            return PutAsync($"Person",new { id = updatePersonRequestDto });
        }

        public Task DeletePersonAsync(DeletePersonRequestDto deletePersonRequestDto)
        {
            return DeleteAsync($"Person",new { id = deletePersonRequestDto.Id });
        }

        public Task LifeEventCreatedAsync(LifeEventCreateDto lifeEventCreateDto)
        {
            return PostAsync($"Person/LifeEventCreated", lifeEventCreateDto);
        }
    }
}