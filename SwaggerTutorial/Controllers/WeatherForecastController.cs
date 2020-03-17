using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerTutorial.Models;

namespace SwaggerTutorial.Controllers
{
    /// <summary>
    /// Weather Forecast Controller
    /// </summary>
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

        /// <summary>
        /// Gets weather forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetForecast")]
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

        /// <summary>
        /// Returns random 5 digits
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Zipcode")]
        public string GetLocationZipCode()
        {
            Random rng = new Random();
            return rng.Next(0, 99999).ToString("D5");
        }

        /// <summary>
        /// Echo back whatever you say
        /// </summary>
        /// <param name="echoModel"></param>
        /// <returns></returns>
        [HttpPost("EchoWords")]
        public string Echo([FromBody] EchoModel echoModel)
        {
            return $"ECHO: {echoModel.EchoText}";
        }
    }
}
