using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
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
        private readonly IPublisherFactory publisherFactory;
        public PersonController(IPersonService personService, IPublisherFactory publisherFactory)
        {
            this.personService = personService;
            this.publisherFactory = publisherFactory;
        }
        
        [HttpGet]
        public async Task<GetPersonsResponseDto> Get(string json)
        {
            var gateWayGetPersonsDto = JsonConvert.DeserializeObject<GetPersonsRequestDto>(json);
            var personModels = await personService.GetAllAsync(gateWayGetPersonsDto.PageNo,gateWayGetPersonsDto.PageSize);

            return new GetPersonsResponseDto() {Persons = Mapper.PersonsModelToDto(personModels)};
        }
        
        [HttpGet("{id}")]
        public async Task<GetPersonResponseDto> Get(GetPersonRequestDto getPersonRequestDto)
        {
            var personModel = await personService.GetByIdAsync(getPersonRequestDto.Id);
            return new GetPersonResponseDto() { Person = Mapper.PersonModelToDto(personModel) };
        }
        
        [HttpPost]
        public async Task Post([FromBody]  UpdatePersonRequestDto updatePersonRequestDto)
        {
            var id = await personService.SaveOrUpdateAsync(Mapper.PersonDtoToModel(updatePersonRequestDto.Person));
            
            var publisher = publisherFactory.Create<PersonCreate>();
            publisher.PublishEventAsync(new PersonCreate() { Id = id});//call and forget
        }
        
        [HttpPut]
        public Task Put([FromBody] UpdatePersonRequestDto updatePersonRequestDto)
        {
            var publisher = publisherFactory.Create<PersonUpdate>();
            publisher.PublishEventAsync(new PersonUpdate() { Id = updatePersonRequestDto.Person.Id});
            
            return personService.SaveOrUpdateAsync(Mapper.PersonDtoToModel(updatePersonRequestDto.Person));
        }
        
        [HttpDelete]
        public Task Delete(DeletePersonRequestDto deletePersonRequestDto)
        {
            var publisher = publisherFactory.Create<PersonDelete>();
            publisher.PublishEventAsync(new PersonDelete() { Id = deletePersonRequestDto.Id});
            
            return personService.DeleteByIdAsync(deletePersonRequestDto.Id);
        }
    }
}