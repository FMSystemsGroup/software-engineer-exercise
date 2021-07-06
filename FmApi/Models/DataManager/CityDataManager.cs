using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FmApi.Models.Repository;
using FmApi.Models.DataTransferObjects;

namespace FmApi.Models.DataManager
{
     public class CityDataManager : IDataRepository<City, CityDto>
     {

          IEnumerable<City> IDataRepository<City, CityDto>.GetAll()
          {
               throw new NotImplementedException();
          }

          IEnumerable<CityDto> IDataRepository<City, CityDto>.GetAllDto()
          {

               List<Nation> nations = new List<Nation>();
               nations.Add(new Nation { id = 1, nationCode = "USA", nationName = "United States of America" });
               nations.Add(new Nation { id = 2, nationCode = "AC", nationName = "Canada" });

               List<State> states = new List<State>();
               states.Add(new State { id = 1, nationId = 1, stateCode = "FL", stateName = "Florida" });
               states.Add(new State { id = 2, nationId = 1, stateCode = "AZ", stateName = "Arizona" });
               states.Add(new State { id = 3, nationId = 1, stateCode = "NC", stateName = "North Carolina" });
               states.Add(new State { id = 4, nationId = 1, stateCode = "CA", stateName = "California" });
               states.Add(new State { id = 5, nationId = 2, stateCode = "NB", stateName = "New Brunswick" });


               List<City> cities = new List<City>();
               cities.Add(new City { id = 1, cityName = "Phoenix", stateid = 2, Latitude = "33.448376", Longitude= "-112.074036" });
               cities.Add(new City { id = 2, cityName = "Raleigh", stateid = 3, Latitude = "35.779591", Longitude = "-78.638176" });
               cities.Add(new City { id = 3, cityName = "San Diego", stateid = 4, Latitude = "32.715736", Longitude = "-117.16108" });
               cities.Add(new City { id = 4, cityName = "Saint John", stateid = 5, Latitude = "45.272812", Longitude = "-66.0630267" });

               var result = from city in cities
                            join state in states on city.stateid equals state.id
                            join nation in nations on state.nationId equals nation.id
                            select new
                            {
                                 CityName = city.cityName,
                                 StateCode = state.stateCode,
                                 StateName = state.stateName,
                                 NationCode = nation.nationCode,
                                 NationName = nation.nationName,
                                 Latitude = city.Latitude,
                                 Longitude = city.Longitude
                            };

               List<CityDto> cr = new List<CityDto>();
               foreach (var item in result)
               {
                    cr.Add(new CityDto { cityName = item.CityName, StateCode = item.StateCode, StateName = item.StateName, NationCode = item.NationCode, NationName = item.NationName, Latitude = item.Latitude, Longitude = item.Longitude });
               }
               return cr;
          }

          IEnumerable<City> IDataRepository<City, CityDto>.GetFiltersList()
          {
               throw new NotImplementedException();
          }

          IEnumerable<City> IDataRepository<City, CityDto>.Get(long Id)
          {
               throw new NotImplementedException();
          }
     }
}
