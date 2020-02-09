using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PersonDiary.Person.Domain.Business;
using PersonDiary.Person.Dto;
using PersonDiary.Person.WebApi.Mappers;

namespace PersonDiary.Person.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        
        [HttpGet]
        public Task<GetPersonsResponseDto> Get(string json)
        {
            throw new NotImplementedException();
            /*
            var gateWayGetPersonsDto = JsonConvert.DeserializeObject<GetPersonsRequestDto>(json);
            var getPersonDto = MapperPerson.GateWayGetPersonsDtoToPersonDto(gateWayGetPersonsDto);
            var getPersonsResponseDto = await personApiClient.GetPersonsAsync(getPersonDto);

            var gateWayGetPersonsResponseDto = MapperPerson.GetPersonsDtoToGateWayDto(getPersonsResponseDto);
            return gateWayGetPersonsResponseDto;
            
            return Task.FromResult(new );
            */
        }
        
        [HttpGet("{id}")]
        public async Task<GetPersonResponseDto> Get(GetPersonRequestDto getPersonRequestDto)
        {
            var personModel = await personService.GetByIdAsync(getPersonRequestDto.Id);
            return new GetPersonResponseDto() { Person = Mapper.PersonModelToDto(personModel) };
        }
        
        [HttpPost]
        public Task Post([FromBody]  UpdatePersonRequestDto updatePersonRequestDto)
        {
            return personService.SaveOrUpdateAsync(Mapper.PersonDtoToModel(updatePersonRequestDto.Person));
        }
        
        [HttpPut]
        public Task Put([FromBody] UpdatePersonRequestDto updatePersonRequestDto)
        {
            return personService.SaveOrUpdateAsync(Mapper.PersonDtoToModel(updatePersonRequestDto.Person));
        }
        
        [HttpDelete]
        public Task Delete(DeletePersonRequestDto deletePersonRequestDto)
        {
            return personService.DeleteByIdAsync(deletePersonRequestDto.Id);
        }
    }
}