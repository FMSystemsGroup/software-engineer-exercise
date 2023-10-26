using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// This class inherits from the IRepositoryManager interface and provides a singleton instance of the city repository class
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICityRepository> _cityRepository;

        /// <summary>
        /// This constructor creates a new instance of the RepositoryManager class and initializes the lazy reference to the city repository class
        /// </summary>
        public RepositoryManager()
        {
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository());
        }

        /// <summary>
        /// This property returns the singleton instance of the city repository class
        /// </summary>
        public ICityRepository City => _cityRepository.Value;
    }
}
