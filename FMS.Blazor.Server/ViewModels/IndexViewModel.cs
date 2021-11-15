
using System.Text.Json.Nodes;

namespace FMS.Blazor.Server.ViewModels;

public interface IIndexViewModel
{
    string[]? Cities { get; }

    Task GetAllCities();

    WeatherForecast WeatherForecastResult { get; set; }

    Task GetWeatherForecast(DateTime localDateTime, string? selectedLocation);
}

public class IndexViewModel : IIndexViewModel
{
    public IndexViewModel(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        this.clientFactory = httpClientFactory;
        this.config = config;
        WeatherForecastResult = new (new DateTime(2018, 7, 4, 12, 0, 0, DateTimeKind.Local));
    }

    IConfiguration config { get; set; }
    private readonly IHttpClientFactory clientFactory;
    
    public string[]? Cities { get; private set; }
    public WeatherForecast WeatherForecastResult { get; set; }

    // Call city api
    public async Task GetAllCities()
    {
        string uri = config["CityApiGetAll"];

        var client = clientFactory.CreateClient(
            name: "City Service Version 1");

        var request = new HttpRequestMessage(
            method: HttpMethod.Get, requestUri: uri);

        HttpResponseMessage response = await client.SendAsync(request);

        var model = await response.Content
            .ReadFromJsonAsync<IEnumerable<string>>();

        Cities = model?.ToArray();
    }

    // Call weather forecast api
    public async Task GetWeatherForecast(DateTime localDateTime, string? selectedLocation)
    {
        // retrieve city from location
        string city = GetCityNameFrom(selectedLocation);

        // determine country code
        string? countrycode = GetCountryCodeFrom(selectedLocation);

        int forecastHourCount = 1;

        // define api key
        string token = config["WeatherForecastAPI"];

        // define api url
        string url = $@"http://history.openweathermap.org/data/2.5/history/city?q={city},{countrycode}&cnt={forecastHourCount}&appid={token}";

        // call weather forecast api
        var client = clientFactory.CreateClient(
            name: "WeatherForecast");

        var request = new HttpRequestMessage(
            method: HttpMethod.Get, requestUri: url);

        HttpResponseMessage response = await client.SendAsync(request);

        var model = await response.Content
            .ReadFromJsonAsync<JsonObject>();

        // Map weather api result to forecast
        WeatherForecastResult = new(localDateTime);

        WeatherForecastResult.StatusCode = response.StatusCode;
    }

    private string GetCityNameFrom(string selectedLocation)
    {
        // Get city name only from substring
        string result = selectedLocation;
        int index = result.IndexOf(",");
        if (index >= 0) result = result.Substring(0, index);

        return result;
    }

    private string GetCountryCodeFrom(string selectedLocation)
    {
        string result = selectedLocation.ToLower().Contains("canada") ? "CA" : "US";
        return result;
    }
}