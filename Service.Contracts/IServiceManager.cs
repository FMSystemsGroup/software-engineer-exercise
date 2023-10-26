using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    /// <summary>
    /// This interface defines the contract for a service manager class that can access the city service 
    /// </summary>
    public interface IServiceManager
    {
        ICityService CityService { get; }   
    }
}
