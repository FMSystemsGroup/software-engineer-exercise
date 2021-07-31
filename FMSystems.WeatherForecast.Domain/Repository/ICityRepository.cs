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
        Task<IEnumerable<City>> GetAllAsync();
    }
}