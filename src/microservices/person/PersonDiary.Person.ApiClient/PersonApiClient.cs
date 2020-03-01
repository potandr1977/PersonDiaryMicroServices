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
            return GetAsync<GetPersonResponseDto>($"api/Person/", getPersonRequestDto);
        }

        public Task<GetPersonsResponseDto> GetPersonsAsync(GetPersonsRequestDto getPersonsRequestDto)
        {
           return GetAsync<GetPersonsResponseDto>(
               $"/api/person/?json={{pageNo: {getPersonsRequestDto.PageNo} ,pageSize:{getPersonsRequestDto.PageSize}}}");
        }

        public Task CreatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto)
        {
            return PostAsync($"api/person/",updatePersonRequestDto);
        }
        
        public Task UpdatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto)
        {
            return PutAsync($"api/person/",new { id = updatePersonRequestDto });
        }

        public Task DeletePersonAsync(DeletePersonRequestDto deletePersonRequestDto)
        {
            return DeleteAsync($"api/person/",new { id = deletePersonRequestDto.Id });
        }

        public Task LifeEventCreatedAsync(LifeEventCreateDto lifeEventCreateDto)
        {
            return PostAsync($"api/person/lifeeventcreated", lifeEventCreateDto);
        }
    }
}