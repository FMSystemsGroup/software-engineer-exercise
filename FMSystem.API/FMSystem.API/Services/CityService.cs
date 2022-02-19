using FMSystem.API.Models;
using System.Collections.Generic;
using FMSystem.API.TestData;
using System.Linq;

namespace FMSystem.API.Services
{
	public class CityService : ICityService
	{
		public IEnumerable<CityModel> get()
		{
			return new CityData().city.Select(x => new CityModel { City = x });
		}
	}
}
