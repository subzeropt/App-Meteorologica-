using System.Threading.Tasks;
using LabApp.Models;

namespace LabApp.Controllers
{
    public interface IAppController
    {
        event Action<User> OnUserAuthenticated;
        event Action<WeatherForecast> OnWeatherUpdated;

        bool Login(string username, string password);
        Task GetWeather(string city);
    }
}
