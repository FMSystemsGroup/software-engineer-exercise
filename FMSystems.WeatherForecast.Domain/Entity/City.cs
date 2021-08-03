using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMSystems.WeatherForecast.Domain.Entity
{
    /// <summary>
    /// A city representation.
    /// </summary>
    [Table("City")]
    public class City : BaseEntity
    {
        /// <summary>
        /// The city name.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// The state where the city is in.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The country where the city is in.
        /// </summary>
        [Required]
        public string Country { get; set; }
        /// <summary>
        /// The latitude.
        /// </summary>
        [Required]
        public double Latitude { get; set; }
        /// <summary>
        /// The longitude.
        /// </summary>
        [Required]
        public double Longitude { get; set; }
    }
}
