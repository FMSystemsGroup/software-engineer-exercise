using System;

namespace FMSystems.WeatherForecast.Domain.Entity
{
    /// <summary>
    /// The forecast representation.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// The date of the forecast.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The temperature in Celsius.
        /// </summary>
        public int TemperatureC { get; set; }
        
        /// <summary>
        /// A quick summary about the forecast.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The temperature in Fahreinheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
