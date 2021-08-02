using FMSystems.WeatherForecast.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Domain.Repository
{
    /// <summary>
    /// A city DB Repository.
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Retrieves all the cities stored in the Database.
        /// </summary>
        /// <returns>A list of cities. <see cref="IEnumerable{City}"/></returns>
        Task<ICollection<City>> GetAllAsync();
        /// <summary>
        /// Retrieves a city by its id.
        /// </summary>
        /// <param name="cityId">the city id</param>
        /// <returns>A city for the given id or null <see cref="City"/></returns>
        Task<City> GetByIdAsync(int cityId);
    }
}