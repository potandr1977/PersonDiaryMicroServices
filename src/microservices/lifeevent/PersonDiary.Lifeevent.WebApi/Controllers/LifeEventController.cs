using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PersonDiary.Lifeevent.Dto;


namespace PersonDiary.React.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        public LifeEventController()
        {
            
        }
        
        [HttpGet]
        public Task<IActionResult> Get(string json)
        {
            throw new NotImplementedException();
            /*
            var resp = await new LifeEventModel(factory, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetLifeEventsDto>(json));
            if (!Parallel.ForEach(resp.LifeEvents, l =>
                    {
                        var responsePerson = new PersonModel(factory, mapper).GetItem(
                            new Contracts.PersonContract.GetPersonRequest() { Id = l.PersonId, withLifeEvents = false }
                        );
                        l.Personfullname = $"{responsePerson.Person.Surname} {responsePerson.Person.Name}";
                    }
                ).IsCompleted
            ) resp.AddMessage(new Contracts.Message("Person full name was not loaded"));

            return resp;
            */
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
            //return await new LifeEventModel(factory, mapper).GetItemAsync(new GetLifeEventRequest() { Id = id });
            //return new JsonResult(answer);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody]  UpdateLifeEventDto request)
        {
            throw new NotImplementedException();
            //return await new LifeEventModel(factory, mapper).CreateAsync(request);
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] UpdateLifeEventDto request)
        {
            throw new NotImplementedException();
            //return await new LifeEventModel(factory, mapper).UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
            //return await new LifeEventModel(factory, mapper).DeleteAsync(new DeleteLifeEventRequest() { Id = id });
        }
    }
}