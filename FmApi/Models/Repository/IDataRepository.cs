using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FmApi.Models.Repository
{
     public interface IDataRepository<TEntity,TDto>
     {
          IEnumerable<TEntity> GetAll();               //Get collection based on the standard class
          IEnumerable<TDto> GetAllDto();               //Get collection based on the dtata transfer objec class
          IEnumerable<TEntity> GetFiltersList();       //not user, created for illustration purposes
          IEnumerable<TEntity> Get(long Id);           //not user, created for illustration purposes
     }
}
