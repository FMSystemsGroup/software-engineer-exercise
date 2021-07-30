using System;
using System.Collections.Generic;
using System.Linq;

namespace FMSystems.WeatherForecast.Application
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<FMSystems.WeatherForcast.Domain.WeatherForecast> GetForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FMSystems.WeatherForcast.Domain.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
