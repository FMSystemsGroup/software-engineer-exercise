using System;

namespace FMSystems.WeatherForecast.Domain.Entity
{
    /// <summary>
    /// The forecast representation.
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// The date and time of the forecast in UTC.
        /// </summary>
        public DateTimeOffset DateTimeUTC { get; set; }

        /// <summary>
        /// The date and time of the forecast.
        /// </summary>
        public DateTimeOffset DateTimeLocal => new DateTimeOffset(DateTimeUTC.DateTime.AddHours(Offset), new TimeSpan(Offset, 0, 0));

        /// <summary>
        /// A quick summary about the forecast.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The icon key for the forecast.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The icon key for the forecast.
        /// </summary>
        public double? UVIndex { get; set; }

        /// <summary>
        /// The temperature in Fahrenheit.
        /// </summary>
        public double? TemperatureF { get; set; }

        /// <summary>
        /// The temperature in Celsius.
        /// </summary>
        public double? TemperatureC => TemperatureF != null ? (TemperatureF - 32) * 5 / 9 : null;

        /// <summary>
        /// The Time offset from UTC.
        /// </summary>
        public int Offset { get; set; }
    }
}
