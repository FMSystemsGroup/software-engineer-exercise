using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Web.Models
{
    public class CityViewModel
    {
        public IEnumerable<CityModel> cityList { get; set; }
        public CityModel dbModel { get; set; }
    }
}
