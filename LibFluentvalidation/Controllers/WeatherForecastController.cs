using FluentValidation;
using LibFluentvalidation.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LibFluentvalidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IValidator<WeatherForecast> _validator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IValidator<WeatherForecast> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public ActionResult Post([FromBody] WeatherForecast forecast)
        {
            var results = _validator.Validate(forecast);
            if(!results.IsValid)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage)));
            }    
            return Ok("Success!");
        }
    }
}