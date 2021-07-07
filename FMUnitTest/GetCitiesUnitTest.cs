using FmApi.Controllers;
using FmApi.Models;
using FmApi.Models.DataManager;
using FmApi.Models.DataTransferObjects;
using FmApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FMUnitTest
{

     public class GetCitiesUnitTest
     {
          private IDataRepository<City, CityDto> _dataRepository;
          private CityController _cityController;

          public GetCitiesUnitTest()
          {
               //_dataRepository = new DataRepositoryTest();
               _dataRepository = new CityDataManager();
               _cityController = new CityController(_dataRepository);
          }

          [Fact]
          public void Get_WhenCalled_ReturnsAllItems()
          {
               //Act 
               IActionResult actionResult = _cityController.Get();

               //Assert
               var okResult = actionResult as OkObjectResult;
               Assert.NotNull(okResult);

               var newBatch = okResult.Value as List<CityDto>;

               Assert.NotNull(newBatch);
               Assert.Equal(4, newBatch.Count);
    
               Assert.Equal(200, okResult.StatusCode);

          }

     }
}
