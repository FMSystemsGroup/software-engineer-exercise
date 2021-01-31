using System;
using System.Collections.Generic;
using System.Text;
using FMSystems.Services.Repository;

namespace FMSystems.Services.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }
      

    }
}
