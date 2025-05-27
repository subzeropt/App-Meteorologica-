using LabApp.Models;
using System.Threading.Tasks;

namespace LabApp.ViewModels
{
    public interface IWeatherViewModel
    {
        WeatherForecast Forecast { get; }
        Task LoadWeather(string city);
        void SetForecast(WeatherForecast forecast);
    }
}


