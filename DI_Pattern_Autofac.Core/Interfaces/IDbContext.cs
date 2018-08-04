using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void BeginTransaction();

        long Commit();

        Task<long> CommitAsync();

        void Rollback();
    }
}