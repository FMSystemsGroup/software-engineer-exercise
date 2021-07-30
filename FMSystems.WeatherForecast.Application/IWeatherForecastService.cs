using System.Collections.Generic;

namespace FMSystems.WeatherForecast.Application
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForcast.Domain.WeatherForecast> GetForecasts();
    }
}