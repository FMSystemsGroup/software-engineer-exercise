using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FmApi.Models;
using System.Net.Http;
using System.Net;
using FmApi.Models.Repository;
using FmApi.Models.DataTransferObjects;

namespace FmApi.Controllers
{
     [Route("api/cities")]
     [ApiController]
     public class CityController : ControllerBase
     {
          private readonly IDataRepository<City, CityDto> _dataRepository;

          public CityController(IDataRepository<City, CityDto> dataRepository)
          {
               _dataRepository = dataRepository;
          }

          [HttpGet]
          public IActionResult Get()
          {
               try
               {
                    var result = _dataRepository.GetAllDto();
                    return Ok(result);
               }
               catch
               {
                    throw new ArgumentException($"API Failure!");
               }
          }
     }
}
