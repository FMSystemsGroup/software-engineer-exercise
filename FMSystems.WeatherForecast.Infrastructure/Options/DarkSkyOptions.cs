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
        /// The default date time in unix time.
        /// </summary>
        public long DefaultUnixTime { get; set; } = 1530705600;

        /// <summary>
        /// The darksky exclude args.
        /// <see cref="https://gist.github.com/releaf/c3c54dc1ab59b86ef037edc125156284"/>
        /// </summary>
        public string ExcludeArgs { get; set; } = "currently,minutely,daily,flags";

        /// <summary>
        /// The unit args.
        /// <see cref="https://gist.github.com/releaf/c3c54dc1ab59b86ef037edc125156284"/>
        /// </summary>
        public string UnitArgs { get; set; } = "us";

        /// <summary>
        /// The language args.
        /// <see cref="https://gist.github.com/releaf/c3c54dc1ab59b86ef037edc125156284"/>
        /// </summary>
        public string LangArgs { get; set; } = "en";
    }
}