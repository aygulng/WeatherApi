using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string ApiKey;
        private readonly string ApiUrl;

        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IOptions<WeatherSettings> weatherSettings, IHttpClientFactory httpClientFactory)
        {
            ApiKey = weatherSettings.Value.ApiKey;
            _httpClientFactory = httpClientFactory;
            ApiUrl = weatherSettings.Value.ApiUrl;
        }

        public async Task<WeatherForecast?> GetCurrentWeatherForCity(string city)
        {
            HttpClient client = _httpClientFactory.CreateClient("weather");

            var response = await client.GetAsync($"{ApiUrl}/data/2.5/weather?q={city}&units=metric&appid={ApiKey}");

            if (response.IsSuccessStatusCode)
            {
                string stringResult = await response.Content.ReadAsStringAsync();
                var rawWeather = JsonConvert.DeserializeObject<WeatherForecast>(stringResult);
                return rawWeather;
            }

            return null;

        }
    }
}
