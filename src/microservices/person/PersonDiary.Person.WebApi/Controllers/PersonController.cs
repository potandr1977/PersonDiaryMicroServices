using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController()
        {
        }
        
        [HttpGet]
        public async Task<GetPersonsResponseDto> Get(string json)
        {
            var gateWayGetPersonsDto = JsonConvert.DeserializeObject<GetPersonsRequestDto>(json);
            var getPersonDto = MapperPerson.GateWayGetPersonsDtoToPersonDto(gateWayGetPersonsDto);
            var getPersonsResponseDto = await personApiClient.GetPersonsAsync(getPersonDto);

            var gateWayGetPersonsResponseDto = MapperPerson.GetPersonsDtoToGateWayDto(getPersonsResponseDto);
            return gateWayGetPersonsResponseDto;
        }
        
        [HttpGet("{id}")]
        public async Task<GetPersonResponseDto> Get(GateWayGetPersonRequestDto getPersonRequestDto)
        {
            var getPersonDto = MapperPerson.GateWayGetPersonDtoToPersonDto(getPersonRequestDto);
            var result = await personApiClient.GetPersonAsync(getPersonDto);
            
            return result;
        }
        
        [HttpPost]
        public Task Post([FromBody]  UpdatePersonRequestDto request)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }
        
        [HttpPut]
        public Task Put([FromBody] UpdatePersonRequestDto request)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }
        
        [HttpDelete]
        public Task Delete(DeletePersonRequestDto deletePersonRequestDto)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }

    }
}