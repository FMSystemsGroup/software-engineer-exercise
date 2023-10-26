using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CityAPI.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {        
        private readonly IServiceManager _services;

        public CitiesController(IServiceManager service) => _services = service;

        [HttpGet]        
        public IActionResult GetCityNames()
        {            
           var cities = _services.CityService.GetCityNames(); 
           return Ok(cities);  
        }
        
    }
}
