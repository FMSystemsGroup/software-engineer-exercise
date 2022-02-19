using FMSystem.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new RestClient("https://localhost:44326/City");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            var model = JsonConvert.DeserializeObject<List<CityModel>>(response.Content);
            return View(new CityViewModel { cityList=model });
        }
        
        
        public JsonResult GetByCity(string city)
        {
            //city = "Arizona";
            var client = new RestClient("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/"+city+"/2018-07-04/2018-07-04?unitGroup=us&include=hours%2Cdays&key=27SD4ATJ9B9L2Q3PDTYC6QWPV&contentType=json");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            JObject jData = JObject.Parse(response.Content);

             var weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(response.Content);

            //"description": "Partly cloudy throughout the day."
            //"temp": 96.9
            //"uvindex": 10.0

            //description (example: Mostly Sunny), temperature (example: 88.81), and UV index (example: 5).
            //loop through array in JSONs

            var conditions = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().conditions;
            var temp = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().temp;
            var uvindex = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().uvindex;

            return Json(new
			{
                conditions,
                temp,
                uvindex
			},  JsonRequestBehavior.AllowGet);
        }
    }

   
    //
}