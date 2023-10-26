using CityAPI.Extensions;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if(app.Environment.IsProduction())
{
    app.UseHsts();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseForwardedHeaders(new ForwardedHeadersOptions 
{ 
    ForwardedHeaders = ForwardedHeaders.All 
}); 

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
