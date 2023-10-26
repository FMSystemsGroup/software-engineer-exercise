using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// This interface defines the contract for a repository manager class that can access the city repository
    /// </summary>
    public interface IRepositoryManager
    {
        ICityRepository City { get; }
    }
}
