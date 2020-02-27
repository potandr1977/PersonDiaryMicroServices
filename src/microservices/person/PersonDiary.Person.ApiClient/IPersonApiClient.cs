using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.ApiClient
{
    public interface IPersonApiClient
    {
        Task<GetPersonResponseDto> GetPersonAsync(GetPersonRequestDto getPersonRequestDto);

        Task<GetPersonsResponseDto> GetPersonsAsync(GetPersonsRequestDto getPersonsRequestDto);

        Task CreatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto);
        
        Task UpdatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto);

        Task DeletePersonAsync(DeletePersonRequestDto deletePersonRequestDto);
        
        Task LifeEventCreatedAsync(LifeEventCreateDto lifeEventCreateDto);
    }
}