using cityAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace City_Api_test
{
    public class CitiesCollectionTest
    {
        cityAPI.Controllers.CitiesCollectionController _controller;
        cityAPI.Models.ICitiesRepository _service;
        public CitiesCollectionTest()
        {
            _service = new CityCollectionFake();
            _controller = new cityAPI.Controllers.CitiesCollectionController(_service);
        }
        [Fact]
        public void GET_Whencalled_Returnallcities()
        {
            

            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<CitiesCollection>(okResult.Value);
            Assert.Equal(3, items.city.Length);
        }
    }
}
