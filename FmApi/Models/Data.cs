using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FmApi.Models
{
     public static class Data
     {
          public static List<Nation> GetNations()
          {
               List<Nation> nations = new List<Nation>();
               nations.Add(new Nation { id = 1, nationCode = "USA", nationName = "United States of America" });
               nations.Add(new Nation { id = 2, nationCode = "AC", nationName = "Canada" });
               return nations;
          }

          public static List<State> GetStates()
          {
               List<State> states = new List<State>();
               states.Add(new State{ id = 1, nationId = 1, stateCode="FL", stateName="Florida"});
               states.Add(new State{ id = 2, nationId = 1, stateCode = "AZ", stateName = "Arizona" });
               states.Add(new State{ id = 3, nationId = 1, stateCode = "NC", stateName = "North Carolina" });
               states.Add(new State{ id = 4, nationId = 1, stateCode = "CA", stateName = "California" });
               states.Add(new State{ id = 5, nationId = 2, stateCode = "NB", stateName = "New Brunswick" });
               return states;
          }

          public static List<City> GetCities()
          {
               List<City> cities = new List<City>();
               cities.Add(new City { id = 1, cityName = "Phoenix", stateid = 2 });
               cities.Add(new City { id = 2, cityName = "Raleigh", stateid = 3 });
               cities.Add(new City { id = 4, cityName = "San Diego", stateid = 4 });
               cities.Add(new City { id = 3, cityName = "Saint John", stateid = 5 });

               return cities;
          }
     }
}
