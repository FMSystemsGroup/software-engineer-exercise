using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Model;
using WeatherApi.Data;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        //location repository field
        private readonly ILocationRepo _repository;

        public LocationsController(ILocationRepo repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Responds to Get verb at route api/Locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations =  await _repository.GetLocationsAsync();

            if(locations == null || locations.ToList().Count ==0)
            {
                return NotFound();
            }

            return Ok(locations);
        }
    }
}
