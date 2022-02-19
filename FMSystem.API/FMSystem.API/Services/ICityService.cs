using FMSystem.API.Models;
using System.Collections.Generic;

namespace FMSystem.API.Services
{
	public interface ICityService
	{
		public IEnumerable<CityModel> get();

	}
}
