using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cityAPI.Models
{
    public class CitiesRepository : ICitiesRepository
    {
        public IEnumerable<CitiesCollection> GetAll() {
            CitiesCollection[] cities= new CitiesCollection[4];

            cities[0] = new CitiesCollection();
            cities[0].city = "Phoenix, AZ";
            cities[1] = new CitiesCollection();
            cities[1].city = "Raleigh, NC";
            cities[2] = new CitiesCollection();
            cities[2].city = "Saint John, NB (Canada)";
            cities[3] = new CitiesCollection();
            cities[3].city = "San Diego, CA";          
            return cities;
        }
    }
}
