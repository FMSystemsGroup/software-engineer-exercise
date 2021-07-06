using FmApi.Controllers;
using FmApi.Models;
using FmApi.Models.DataTransferObjects;
using FmApi.Models.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace FMUnitTest
{
     public class UnitTest
     {
          CityController _cityControllerTest;
          IDataRepository<City, CityDto> _dataRepository;

          //private readonly IDataRepository<City, CityDto> _dataRepository;

          //public CityController(IDataRepository<City, CityDto> dataRepository)
          //{
          //     _dataRepository = dataRepository;
          //}

          public UnitTest()
          {
               _cityControllerTest = new CityController(_dataRepository);
          }

          [Fact]
          public void Get_WhenCalled_ReturnsAllItems()
          {
               //Act 
               //var okResult = _cityControllerTest.Get().ExecuteResultAsync as OkObjectResult;
               var okResult = _cityControllerTest.Get();

               //Assert
               var items = Assert.IsType<List<CityDto>>(okResult.GetType());
               Assert.Equal(4, items.Count);
          }
     }
}
