using DI_Pattern_Autofac.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(long id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }


public interface IRepository : IDisposable
    {
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        System.Linq.IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : BaseModel<int>;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
    }
}
