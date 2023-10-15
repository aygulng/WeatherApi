using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast?> GetCurrentWeatherForCity(string city);
        Task<List<WeatherForecast?>> GetCitiesWithWeather();
    }
}
