using System.Threading.Tasks;
using LabApp.Models;

namespace LabApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherAsync(string city);
    }
}
