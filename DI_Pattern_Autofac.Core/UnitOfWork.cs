using DI_Pattern_Autofac.Core.Interfaces;
using DI_Pattern_Autofac.Core.Model;
using DI_Pattern_Autofac.Core.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DI_Pattern_Autofac.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(BaseRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IRepository<TEntity>)_repositories[type];
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public long Commit()
        {
            return _context.Commit();
        }

        public Task<long> CommitAsync()
        {
            return _context.CommitAsync();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();
                }
            }
            _disposed = true;
        }


    }
}