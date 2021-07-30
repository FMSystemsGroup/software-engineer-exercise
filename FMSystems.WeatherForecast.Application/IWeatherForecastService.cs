using System.Collections.Generic;

namespace FMSystems.WeatherForecast.Application
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast.Domain.WeatherForecast> GetForecasts();
    }
}