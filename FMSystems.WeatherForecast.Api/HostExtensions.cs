using FMSystems.WeatherForecast.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Api
{
    internal static class HostExtensions
    {
        public static IHost RunEntityFrameworkMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            try
            {
                Console.WriteLine("--> DB Migration - START <--");
                scope.ServiceProvider.GetService<WeatherForecastDbContext>().Database.Migrate();
                scope.ServiceProvider.GetService<WeatherForecastDbContext>().SaveChanges();
                Console.WriteLine("MIGRATION_SUCCESS");
                Console.WriteLine("--> DB Migration - END <--");
            }
            catch (Exception ex)
            {
                Console.WriteLine("--> DB Migration - FAIL <--");
                scope.ServiceProvider.GetService<ILogger<Program>>().LogError(ex, "Failed Migration");
                Console.WriteLine("MIGRATION_FAILURE");
                throw;
            }

            return host;
        }
    }
}
