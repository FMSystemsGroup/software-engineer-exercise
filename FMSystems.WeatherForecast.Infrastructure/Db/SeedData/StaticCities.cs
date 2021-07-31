using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Db.SeedData
{
    public static class StaticCities
    {
        public static readonly City PhoenixAzUs = new City() { Id = 1, Name = "Phoenix", Country = "US", State = "AZ", Latitude = 33.448376, Longitude = -112.074036 };

        public static readonly City RaleighNcUs = new City() { Id = 2, Name = "Raleigh", Country = "US", State = "NC", Latitude = 35.787743, Longitude = -78.644257 };

        public static readonly City StJohnNbCa = new City() { Id = 3, Name = "Saint John", Country = "CA", State = "NB", Latitude = 45.273918, Longitude = -66.067657 };

        public static readonly City SanDiegoCaUs = new City() { Id = 4, Name = "San Diego", Country = "US", State = "CA", Latitude = 32.715736, Longitude = -117.161087 };

        public static IEnumerable<City> GetAll() =>
            new[]
            {
                PhoenixAzUs,
                RaleighNcUs,
                StJohnNbCa,
                SanDiegoCaUs,
            };
    }
}
