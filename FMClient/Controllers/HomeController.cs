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
          //test
          private IConfiguration configuration;
          public HomeController(IConfiguration config)
          {
               configuration = config;
          }
          //test

          public async Task<IActionResult> Index()
          {
               string port = configuration.GetSection("FMClientConfig").GetSection("FmApiPort").Value;
               string dsKey = configuration.GetSection("FMClientConfig").GetSection("DSKey").Value;
               string url = "https://localhost:" + port + "/api/cities";

               List<City> cities = new List<City>();
               using (var httpClient = new HttpClient())
               {
                    using (var response = await httpClient.GetAsync(url))
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
