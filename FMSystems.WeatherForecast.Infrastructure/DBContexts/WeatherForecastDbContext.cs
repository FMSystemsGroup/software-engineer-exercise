
using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.DBContexts
{
    public class WeatherForecastDbContext : DbContext, IWeatherForecastDbContext
    {
        public WeatherForecastDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(StaticCities.GetAll());
        }
    }
}
