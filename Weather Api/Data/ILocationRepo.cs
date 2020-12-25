using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Model;
            
namespace WeatherApi.Data
{
    public interface ILocationRepo
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
    }
}
