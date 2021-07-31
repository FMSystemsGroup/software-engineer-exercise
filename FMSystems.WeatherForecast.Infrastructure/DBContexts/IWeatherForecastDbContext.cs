using FMSystems.WeatherForecast.Domain;
using Microsoft.EntityFrameworkCore;

namespace FMSystems.WeatherForecast.Infrastructure.DBContexts
{
    public interface IWeatherForecastDbContext
    {
        DbSet<City> Cities { get; set; }
    }
}