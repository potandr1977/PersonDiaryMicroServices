using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonDiary.GateWay.ApiClient;
using PersonDiary.GateWay.Dto;
using PersonDiary.GateWay.Mappers;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonApiClient personApiClient;
        public PersonController(IPersonApiClient personApiClient)
        {
            this.personApiClient = personApiClient;
        }
        
        [HttpGet]
        public async Task<GateWayGetPersonsResponseDto> Get(string json)
        {
            var gateWayGetPersonsDto = JsonConvert.DeserializeObject<GateWayGetPersonsRequestDto>(json);
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