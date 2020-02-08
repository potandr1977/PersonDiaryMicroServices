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
            //byte[] bytes = await new PersonModel(factory, mapper).DownloadAsync(new GetPersonRequest() { Id = id });
            //return File(bytes, "application/octet-stream", "biographi.docx");
        }

        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public Task<IActionResult> Post(string json)
        {
            throw new NotImplementedException();
            //PersonUploadRequest request = JsonConvert.DeserializeObject<PersonUploadRequest>(json);
            //return await UploadBiography(request);
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id)
        {
            throw new NotImplementedException();
            //return await UploadBiography(new PersonUploadRequest() { PersonId = id });
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
            //return await Task.Run(() => new PersonModel(factory, mapper).DeleteBiography(new DeletePersonRequest() { Id = id }));
        }
        
        private Task<IActionResult> UploadBiography(PersonUploadRequestDto request)
        {
            throw new NotImplementedException();
            /*
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length == 0) return new PersonUploadResponse().AddMessage(new Contracts.Message("Zero files proveided"));
                if (!file.FileName.Contains(".doc")) return new PersonUploadResponse().AddMessage(new Contracts.Message("Only .doc/docx file types allowed"));
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    request.Biography = binaryReader.ReadBytes((int)file.Length);
                    return await new PersonModel(factory, mapper).UploadAsync(request);
                }
            }
            catch (Exception e)
            {
                return new PersonUploadResponse().AddMessage(new Contracts.Message(e.Message));
            }
            */
        }
    }
}
