using System.ComponentModel.DataAnnotations;
using System.Net;

namespace FMS.Shared;

public class WeatherForecast
{
    public WeatherForecast(DateTime? date)
    {
        Date = date;
    }

    public WeatherForecast(DateTime? date, string? description, string? temperature, string? uvIndex)
    {
        Date = date;
        Description = description;
        Temperature = temperature;
        UVIndex = uvIndex;
    }

    public DateTime? Date { get; private set; }
    public string? Description { get; private set; }
    public string? Temperature { get; private set; }
    public string? UVIndex { get; private set; }
    public HttpStatusCode StatusCode { get; set; }
}