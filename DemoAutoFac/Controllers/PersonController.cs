using DemoAutoFac.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoFac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personServic)
        {
            _personService = personServic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();

            return Ok(result);
        }
    }
}
