using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FmApi.Models
{
     public class City
     {
          public int id { get; set; }
          public int stateid { get; set; }
          public string  cityName { get; set; }
          public string Latitude { get; set; }
          public string Longitude { get; set; }
     }
}
