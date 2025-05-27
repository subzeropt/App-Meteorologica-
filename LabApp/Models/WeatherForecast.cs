using System.Collections.Generic;

namespace LabApp.Models
{
    public class WeatherForecast
    {
        public string City { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<DailyForecast> Forecasts { get; set; } = new();
    }
}

