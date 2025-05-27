using System;
using System.Threading.Tasks;
using LabApp.Models;
using LabApp.Services;

namespace LabApp.Controllers
{
    public class AppController : IAppController
    {
        private readonly IAuthService _authService;
        private readonly IWeatherService _weatherService;

        public event Action<User>? OnUserAuthenticated;
        public event Action<WeatherForecast>? OnWeatherUpdated;

        public AppController(IAuthService authService, IWeatherService weatherService)
        {
            _authService = authService;
            _weatherService = weatherService;
        }

        public bool Login(string username, string password)
        {
            if (_authService.Authenticate(username, password))
            {
                OnUserAuthenticated?.Invoke(new User { Username = username });
                return true;
            }
            return false;
        }

        public async Task GetWeather(string city)
        {
            var forecast = await _weatherService.GetWeatherAsync(city);
            OnWeatherUpdated?.Invoke(forecast);
        }
    }
}

