using FMSystems.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.Services.Repository.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<List<City>> GetCities();

    }
}
