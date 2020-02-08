using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.ApiClient
{
    public interface IPersonApiClient
    {
        Task<GetPersonResponseDto> GetPeron(GetPersonRequestDto getPersonRequestDto);

        Task<GetPersonsResponseDto> GetPersons(GetPersonsRequestDto getPersonsRequestDto);

        Task CreatePerson(UpdatePersonRequestDto updatePersonRequestDto);
        
        Task UpdatePerson(UpdatePersonRequestDto updatePersonRequestDto);

        Task DeletePerson(DeletePersonRequestDto deletePersonRequestDto);
    }
}