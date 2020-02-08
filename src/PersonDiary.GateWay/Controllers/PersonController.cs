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
        public async Task<ActionResult> Get(string json)
        {
            var gateWayGetPersonsDto = JsonConvert.DeserializeObject<GateWayGetPersonsDto>(json);
            var getPersonDto = Mapper.GateWayGetPersonsDtoToPersonDto(gateWayGetPersonsDto);
            var result = await personApiClient.GetPersons(getPersonDto);
            return Ok(result);
            //return await new PersonModel(factory, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetPersonListRequest>(json));
            //return Ok(answer);
        }
        
        [HttpGet("{id}")]
        public Task<ActionResult> Get(GetPersonRequestDto getPersonRequestDto)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }
        
        [HttpPost]
        public Task<ActionResult> Post([FromBody]  UpdatePersonRequestDto request)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }
        
        [HttpPut]
        public Task<ActionResult> Put([FromBody] UpdatePersonRequestDto request)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }
        
        [HttpDelete]
        public Task<ActionResult> Delete(DeletePersonRequestDto deletePersonRequestDto)
        {
            throw new NotImplementedException();
            //return Ok(answer);
        }

    }
}