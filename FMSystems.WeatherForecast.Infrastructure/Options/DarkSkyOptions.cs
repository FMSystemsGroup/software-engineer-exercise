using System;

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

        /// <summary>
        /// The default date time.
        /// </summary>
        public string DefaultDateTime { get; set; } = "2018-07-04 12:00 PM";

        /// <summary>
        /// The default date time in unix time.
        /// </summary>
        public long DefaultDateTimeUnix
        {
            get
            {
                return ((DateTimeOffset)DateTime.ParseExact(DefaultDateTime, "yyyy-MM-dd HH:mm tt", null)).ToUnixTimeSeconds();
            }
        }

        /// <summary>
        /// The darksky exclude args.
        /// </summary>
        public string ExcludeArgs { get; set; } = "currently,minutely,daily,flags";
    }
}