using Contracts;
using Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// This class implements the ICityService interface and provides a method to get the city names from the repository
    /// </summary>
    internal sealed class CityService : ICityService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        /// <summary>
        /// This constructor creates a new instance of the CityService class and injects the dependencies for the logger and the repository
        /// </summary>
        /// <param name="repository">This parameter holds a reference to the repository manager class that implements the IRepositoryManager interface</param>
        /// <param name="logger">This parameter holds a reference to the logger manager class that implements the ILoggerManager interface</param>
        public CityService(IRepositoryManager repository, ILoggerManager logger)
        {
           _logger = logger;   
            _repository = repository; 
        }

        /// <summary>
        /// This method returns a list of city objects from the city repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<City> GetCityNames()
        {            
            var cities = _repository.City.GetCities();
            return cities;
        }
    }
}
