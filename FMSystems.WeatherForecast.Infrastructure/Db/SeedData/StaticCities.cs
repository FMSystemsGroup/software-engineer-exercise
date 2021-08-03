using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Db.SeedData
{
   /// <summary>
   /// Static class for the seed data.
   /// </summary>
    public static class StaticCities
    {
        /// <summary>
        /// The Seed data.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<City> GetAll() =>
            new[]
            {
                new City() { Id = 1, Name = "Phoenix", Country = "United States", State = "AZ", Latitude = 33.448376, Longitude = -112.074036 },
                new City() { Id = 2, Name = "Raleigh", Country = "United States", State = "NC", Latitude = 35.787743, Longitude = -78.644257 },
                new City() { Id = 3, Name = "Saint John", Country = "Canada", State = "NB", Latitude = 45.273918, Longitude = -66.067657 },
                new City() { Id = 4, Name = "San Diego", Country = "United States", State = "CA", Latitude = 32.715736, Longitude = -117.161087 },
            };
    }
}
