using FMSystems.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCities();
    }
}
