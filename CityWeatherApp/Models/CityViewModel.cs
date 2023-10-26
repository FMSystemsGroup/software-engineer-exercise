using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityWeatherApp.Models
{
    public class CityViewModel
    {              
       public string SelectedValue { get; set; }
      
       public IEnumerable<SelectListItem> Cities { get; set; }     

    }
}
