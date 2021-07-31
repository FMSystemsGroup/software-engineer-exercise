using System.Collections.Generic;

namespace FMSystems.WeatherForecast.Domain.Service
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast.Domain.Entity.WeatherForecast> GetForecasts();
    }
}