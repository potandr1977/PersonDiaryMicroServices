using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonFileController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnviroment;

        public PersonFileController(IWebHostEnvironment webHostEnviroment)
        {
            this.webHostEnviroment = webHostEnviroment;
        }

        [HttpGet("{id}")]
        public Task<FileResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public Task<IActionResult> Post(string json)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        private Task<IActionResult> UploadBiography(PersonUploadRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
