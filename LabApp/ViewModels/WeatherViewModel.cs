using LabApp.Controllers;
using LabApp.Models;
using LabApp.ViewModels;
using System.Threading.Tasks;

namespace LabApp.ViewModels
{
    public class WeatherViewModel : IWeatherViewModel
    {
        private readonly IAppController _appController;

        public WeatherViewModel(IAppController appController)
        {
            _appController = appController;
        }

        public WeatherForecast Forecast { get; private set; }

        public async Task LoadWeather(string city)
        {
            await _appController.GetWeather(city);
        }

        public void SetForecast(WeatherForecast forecast)
        {
            Forecast = forecast;
        }
    }
}


