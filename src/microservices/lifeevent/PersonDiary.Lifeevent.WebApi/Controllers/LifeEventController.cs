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
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody]  UpdateLifeEventDto request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] UpdateLifeEventDto request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        [Route("PersonCreated")]
        public Task<IActionResult> PersonCreatedAsync([FromBody]  PersonCreateDto personCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}