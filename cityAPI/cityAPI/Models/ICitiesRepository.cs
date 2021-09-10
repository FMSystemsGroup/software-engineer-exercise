using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cityAPI.Models
{
    public interface ICitiesRepository
    {

        IEnumerable<CitiesCollection> GetAll();
    }
}
