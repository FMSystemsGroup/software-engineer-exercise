using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// This interface defines a contract for a city repository that can retrieve a list of cities
    /// </summary>
    public interface ICityRepository
    {
        List<City> GetCities();
    }
}
