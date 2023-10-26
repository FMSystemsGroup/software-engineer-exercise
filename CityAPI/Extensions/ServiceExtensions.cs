using Contracts;
using LoggerService;
using Repository;
using Service;
using Service.Contracts;

namespace CityAPI.Extensions
{
    /// <summary>
    /// This class contains extension methods for the IServiceCollection interface that can configure the services for the web application
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// This method adds a scoped service for the service manager class that implements the IServiceManager interface
        /// </summary>
        /// <param name="services"></param>         
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        /// <summary>
        /// This method adds a scoped service for the repository manager class that implements the IRepositoryManager interface
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        /// <summary>
        /// This method adds a singleton service for the logger manager class that implements the ILoggerManager interface
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        /// <summary>
        /// This method adds a CORS policy that allows any origin, method, and header to access the web application
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });       

    }
}
