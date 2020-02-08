using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PersonDiary.Person.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public PingController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok("ping!");
        }
    }
}