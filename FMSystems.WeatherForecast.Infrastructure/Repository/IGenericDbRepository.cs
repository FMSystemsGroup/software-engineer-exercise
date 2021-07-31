﻿using FMSystems.WeatherForecast.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Repository
{
    public interface IGenericDbRepository<TEntity> where TEntity : BaseEntity
    {
        void Delete(TEntity entityToDelete);
        Task DeleteAsync(object id);
        void Dispose();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetByIDAsync(object id);
        Task InsertAsync(TEntity entity);
        Task SaveAsync();
        void Update(TEntity entityToUpdate);
    }
}