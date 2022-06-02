using DemoScrutor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoScrutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }
        
    }
}
