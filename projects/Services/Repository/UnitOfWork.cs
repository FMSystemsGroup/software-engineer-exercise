using FMSystems.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMSystems.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICityRepository Cities { get; }

        public UnitOfWork(ICityRepository cityRepository)
        {
            Cities = cityRepository; 
        }
    

    }
}
