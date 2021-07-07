using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FMClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Dynamic;
using Microsoft.Extensions.Configuration;

namespace FMClient.Controllers
{
     public class HomeController : Controller
     {
        
          private IConfiguration configuration;
          public HomeController(IConfiguration config)
          {
               configuration = config;
          }
          

          public async Task<IActionResult> Index()
          {
               //string port = configuration.GetSection("FMClientConfig").GetSection("FmApiPort").Value;
               string fmApiUrl = configuration.GetSection("FMClientConfig").GetSection("FmApiUrl").Value;
               string dsKey = configuration.GetSection("FMClientConfig").GetSection("DSKey").Value;
            
               //this hardcoded url will not work if depoyed to a remote host
               //string url = "https://localhost:" + port + "/api/cities";
               //string url = "https://fmapidemo.azurewebsites.net/api/cities";

               List<City> cities = new List<City>();
               using (var httpClient = new HttpClient())
               {
                    //using (var response = await httpClient.GetAsync(url))
                    using (var response = await httpClient.GetAsync(fmApiUrl))
                    {
                         string apiResponse = await response.Content.ReadAsStringAsync();
                         cities = JsonConvert.DeserializeObject<List<City>>(apiResponse);
                    }

                    //Used for test
                    //IEnumerable<SelectListItem> items = cities.Select(c => new SelectListItem { Value = c.StateCode, Text= c.cityName });

                    City cityOptions = new City();
                    cityOptions.Cities = cities;
                    ViewModel mymodel = new ViewModel();
                    mymodel.CityObjects = cities;
                    mymodel.CityOptions = cityOptions;
                    mymodel.dsKey = dsKey;
                    return View(mymodel);
               }
          }
     }
}
