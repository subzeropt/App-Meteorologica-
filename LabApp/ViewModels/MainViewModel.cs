using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabApp.Controllers;
using LabApp.Models;

namespace LabApp.ViewModels
{
    public class MainViewModel
    {
        private readonly IAppController _controller;

        public string City { get; set; } = "Lisboa";
        public string Temperature { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public List<DailyForecast> Forecasts { get; private set; } = new();
        public bool HasError { get; private set; } = false;

        public event Action? StateChanged;

        public MainViewModel(IAppController controller)
        {
            _controller = controller;

            _controller.OnUserAuthenticated += user =>
                Console.WriteLine($"Bem-vindo {user.Username}!");

            _controller.OnWeatherUpdated += forecast =>
            {
                Temperature = forecast.Temperature;
                Description = forecast.Description;
                Forecasts = forecast.Forecasts;
                HasError = false;
                NotifyStateChanged();
            };
        }

        public bool Login(string username, string password)
        {
            return _controller.Login(username, password);
        }

        public async Task FetchWeather()
        {
            try
            {
                await _controller.GetWeather(City);
            }
            catch
            {
                HasError = true;
                Forecasts.Clear();
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => StateChanged?.Invoke();
    }
}

