using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using LabApp.Models;


namespace LabApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast> GetWeatherAsync(string city)
        {
            var url = $"https://wttr.in/{city}?format=j1";
            var response = await _httpClient.GetStringAsync(url);

            dynamic data = JsonConvert.DeserializeObject(response)!;

            var forecast = new WeatherForecast
            {
                City = city,
                Temperature = data.current_condition[0].temp_C + " °C",
                Description = data.current_condition[0].weatherDesc[0].value
            };

            foreach (var day in data.weather)
            {
                forecast.Forecasts.Add(new DailyForecast
                {
                    Date = day.date,
                    MinTemp = day.mintempC + " °C",
                    MaxTemp = day.maxtempC + " °C",
                    Description = day.hourly[4].weatherDesc[0].value
                });
            }

            return forecast;
        }
    }
}

