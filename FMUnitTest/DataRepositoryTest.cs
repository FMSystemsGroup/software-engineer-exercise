using FmApi.Models;
using FmApi.Models.DataTransferObjects;
using FmApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMUnitTest
{
     class DataRepositoryTest : IDataRepository<City, CityDto>
     {
          IEnumerable<City> IDataRepository<City, CityDto>.Get(long Id)
          {
               throw new NotImplementedException();
          }

          IEnumerable<City> IDataRepository<City, CityDto>.GetAll()
          {
               throw new NotImplementedException();
          }

          IEnumerable<CityDto> IDataRepository<City, CityDto>.GetAllDto()
          {
               throw new NotImplementedException();
          }

          IEnumerable<City> IDataRepository<City, CityDto>.GetFiltersList()
          {
               throw new NotImplementedException();
          }
     }
}
