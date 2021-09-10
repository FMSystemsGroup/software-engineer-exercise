using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesCollectionController : ControllerBase
    {
        public  CitiesCollectionController(Models.ICitiesRepository citirepo) { CityRepo = citirepo; }

       
        public ICitiesRepository CityRepo { get; set; }
        // GET: api/<CitiesCollection>
        [HttpGet]
        public IEnumerable<CitiesCollection> GetAll()
        {
           return CityRepo.GetAll();
        }

   
    }
}
