namespace FMSystems.WeatherForecast.Infrastructure.Options
{
    /// <summary>
    /// An options object that contains environment values fro the application.
    /// </summary>
    public class DarkSkyOptions
    {
        /// <summary>
        /// The holder for the dark sky api key.
        /// </summary>
        public string ApiKey { get; set; }
    }
}