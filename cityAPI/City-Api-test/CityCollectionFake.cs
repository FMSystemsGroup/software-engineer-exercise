using System;
using System.Collections.Generic;
using System.Text;
using cityAPI;
using cityAPI.Models;

namespace City_Api_test
{
    class CityCollectionFake:ICitiesRepository
    {
        IEnumerable<CitiesCollection> ICitiesRepository.GetAll()
        {
            cityAPI.CitiesCollection[] cities = new cityAPI.CitiesCollection[4];

            cities[0] = new cityAPI.CitiesCollection();
            cities[0].city = "Phoenix, AZ";
            cities[1] = new cityAPI.CitiesCollection();
            cities[1].city = "Raleigh, NC";
            cities[2] = new cityAPI.CitiesCollection();
            cities[2].city = "Saint John, NB (Canada)";
            cities[3] = new cityAPI.CitiesCollection();
            cities[3].city = "San Diego, CA";
            return cities;
        }

       
    }
}
