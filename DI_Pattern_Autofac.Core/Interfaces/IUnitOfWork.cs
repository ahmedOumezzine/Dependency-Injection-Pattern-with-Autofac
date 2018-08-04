using System;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void BeginTransaction();

        long Commit();

        Task<long> CommitAsync();

        void Rollback();

        void Dispose(bool disposing);
    }
}