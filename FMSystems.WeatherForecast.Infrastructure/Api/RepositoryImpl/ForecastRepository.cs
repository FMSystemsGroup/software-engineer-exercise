using FMSystems.WeatherForecast.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMSystems.WeatherForecast.Infrastructure.Api.RepositoryImpl
{
    public class ForecastRepository : IForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<FMSystems.WeatherForecast.Domain.Entity.WeatherForecast> GetForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FMSystems.WeatherForecast.Domain.Entity.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
