using System.Collections.Generic;

namespace FMSystems.WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast.Domain.WeatherForecast> GetForecasts();
    }
}