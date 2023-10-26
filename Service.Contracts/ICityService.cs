using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    /// <summary>
    /// This interface defines the contract for a city service class that can provide a list of city names
    /// </summary>
    public interface ICityService
    {
        /// <summary>
        /// This method returns an enumerable collection of city objects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<City> GetCityNames();
    }
}
