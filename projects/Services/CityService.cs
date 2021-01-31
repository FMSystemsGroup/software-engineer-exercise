using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMSystems.Services.Repository;
using FMSystems.Services.Repository.Interfaces;
using FMSystems.Services.Interfaces;
using FMSystems.Shared.DTO;
using Serilog;


namespace FMSystems.Services
{

    public class CityService : ICityService
    {
        private IUnitOfWork uow { get; set; }


        public CityService(IUnitOfWork unitOfWork) 
        {
            this.uow = unitOfWork;
        }

        /// <summary>
        /// Gets a list of the cities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<City>> GetCities()
        {
            //business logic goes here...
            return await uow.Cities.GetCities();
        }
    }
}
