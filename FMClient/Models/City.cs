﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMClient.Models
{
     public class City
     {
          public string cityName { get; set; }
          public string StateCode { get; set; }
          public string StateName { get; set; }
          public string NationCode { get; set; }
          public string NationName { get; set; }
          public string Latitude { get; set; }
          public string Longitude { get; set; }
          public List<City> Cities { get; set; }
     }
}