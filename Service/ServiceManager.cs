using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// This class implements the IServiceManager interface and provides a singleton instance of the city service class
    /// </summary>
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<ICityService> _cityService;

        /// <summary>
        /// This constructor creates a new instance of the ServiceManager class and injects the dependencies for the repository manager and the logger
        /// </summary>
        /// <param name="repositoryManager"></param>
        /// <param name="logger"></param>
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _cityService = new Lazy<ICityService>(() => new
            CityService(repositoryManager, logger));     
        }

        public ICityService CityService => _cityService.Value;
    }
}
