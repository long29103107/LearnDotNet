using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSerilog.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(template: "/api/error/{id}")]
        public ActionResult<string> GetError(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception($"id cannot be less than or equal to 0:{id}");
                }

                return Ok($"id is:{id}");

            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Error message:{ex.Message}");
                sb.AppendLine($"Error stack trace:{ex.StackTrace}");
                _logger.LogError(sb.ToString());
            }

            return BadRequest("bad request");
        }
    }
}
