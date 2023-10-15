using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("weather/{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weather = await _weatherService.GetCurrentWeatherForCity(city);

            if (weather != null)
            {
                return Ok(weather);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("cities")]
        public async Task<ActionResult<List<WeatherForecast>>> GetCitiesWithWeather()
        {
            var citiesWithWeather = await _weatherService.GetCitiesWithWeather();
            return Ok(citiesWithWeather);
        }

    }
}