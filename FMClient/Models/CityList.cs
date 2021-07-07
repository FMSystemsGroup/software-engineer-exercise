using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMClient.Models
{
     public class  CityList
     {
          public List<City> cities { get; set; }
          public CityList(List<City> cityList)
          {
               this.cities = cityList;
          }
     }
}
