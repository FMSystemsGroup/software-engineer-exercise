using FMSystem.Web.Models;
using Newtonsoft.Json;
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
            var client = new RestClient("https://localhost:44379/City");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
			var model = JsonConvert.DeserializeObject<List<CityModel>>(response.Content);
			return View(new CityViewModel { cityList = model });
		}

        public JsonResult GetByCity(string city)
        {
            ;
            var client = new RestClient("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "/2018-07-04/2018-07-04?unitGroup=us&include=hours%2Cdays&key="+System.Configuration.ConfigurationManager.AppSettings["DarkSkyKey"].ToString()+"&contentType=json");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(response.Content);
            var conditions = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().conditions;
            var temp = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().temp;
            var uvindex = weatherData.days.FirstOrDefault().hours.Where(h => h.datetime == "12:00:00").FirstOrDefault().uvindex;

            return Json(new
            {
                conditions,
                temp,
                uvindex
            }, JsonRequestBehavior.AllowGet);
        }
    }
}