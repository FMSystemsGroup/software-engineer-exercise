using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherFetchAPI.Models;

namespace WeatherFetchAPI
{
	public class Startup
	{
		public Startup(IWebHostEnvironment env)
		{
			//In order to set up the app settings correctly for testing
			//the file needs to be loaded here instead of being passed in
			//otherwise the configs don't get loaded correctly when running tests
			Configuration = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json")
				.AddEnvironmentVariables()
				.Build();
		}

		public IConfiguration Configuration { get; }
		readonly string AllowedOrigins = "_allowedOrigins";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			var appSettingsSection = Configuration.GetSection("AppSettings");
			var appSettings = appSettingsSection.Get<AppSettings>();
			services.Configure<AppSettings>(appSettingsSection);
			services.AddSingleton<IConfiguration>(Configuration);
			services.AddDbContext<WeatherFetchContext>(options =>
				options.UseSqlite($"Data Source={appSettings.DatabaseFileName}"));
			var corsOrigin = Configuration.GetValue<string>("AllowedCORS");
			services.AddCors(options =>
			{
				options.AddPolicy(name: AllowedOrigins,
					builder =>
					{
						builder.WithOrigins(corsOrigin)
						.WithMethods("OPTIONS", "GET", "POST") //only allow GET and POST requests
						.AllowAnyHeader();
					}
				);

			});
			services.AddControllers()
				.AddNewtonsoftJson(options => {
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				});
			services.AddHttpClient();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(AllowedOrigins);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
