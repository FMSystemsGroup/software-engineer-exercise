using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// This class implements the ICityRepository interface and returns a list of city objects
    /// </summary>
    public class CityRepository : ICityRepository
    {
        /// <summary>
        /// This method returns a list of four cities with their name, state, and country properties
        /// </summary>
        /// <returns></returns>
        public List<City> GetCities()
        {
            return new List<City>
            {
                new City { Name = "Phoenix", State = "AZ", Country = "USA" },
                new City { Name = "Raleigh", State = "NC", Country = "USA" },
                new City { Name = "Saint John", State = "NB", Country = "Canada" },
                new City { Name = "San Diego", State = "CA", Country = "USA" }
            };
        }
    }
}
