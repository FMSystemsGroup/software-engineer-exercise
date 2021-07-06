using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMClient.Models
{
     public class ViewModel
     {
          public City CityOptions { get; set; }
          public IEnumerable<City> CityObjects { get; set; }
          public string dsKey { get; set; }
     }
}
