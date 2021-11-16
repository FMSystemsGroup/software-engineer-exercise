
var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

string? apiBaseAddress = null;

#if DEBUG
    apiBaseAddress = configuration["CityApiUri_Debug"];

    builder.Services.AddHttpClient(name: "City Service Version 1",
        configureClient: options => {
          options.BaseAddress = new Uri(apiBaseAddress);
          options.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue(
                  "appliction/json", 1.0));
  });
#else
    apiBaseAddress = configuration["CityApiUri_Release"];

    builder.Services.AddHttpClient(name: "City Service Version 1",
        configureClient: options => {
          options.BaseAddress = new Uri(apiBaseAddress);
          options.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue(
                  "appliction/json", 1.0));
    });
#endif

// Add services to the container.

builder.Services.AddTransient<CityApiService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(); // Free UI Components Library
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<ICityApiService, CityApiService>();

// Add middleware pipeline.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();