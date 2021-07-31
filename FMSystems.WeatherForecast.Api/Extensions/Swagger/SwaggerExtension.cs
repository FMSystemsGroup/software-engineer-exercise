using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Api.Extensions.Swagger
{
    /// <summary>
    /// A services collection extension to encapulate the swagger setup.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Configuration to include the swagger gen service and its configuration.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Extension to add the Swagger UI page.
        /// </summary>
        /// <param name="app"></param>
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast Api");
                   options.DisplayOperationId();
               });
        }
    }
}
