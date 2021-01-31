using FMSystems.Services.Interfaces;
using FMSystems.Services.Repository;
using FMSystems.Services.Repository.Interfaces;
using FMSystems.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMSystems.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
       
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IWeatherService, DSService>();

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
