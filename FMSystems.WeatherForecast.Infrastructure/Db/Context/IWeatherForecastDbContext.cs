using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMSystems.WeatherForecast.Infrastructure.Db.Context
{
    public interface IWeatherForecastDbContext
    {
        DbSet<City> Cities { get; set; }
    }
}