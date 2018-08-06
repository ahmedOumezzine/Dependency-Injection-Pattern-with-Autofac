﻿using GRLibrary.ContextFactory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;
        /// <summary>
        /// NOTE: repository getters instantiate repositories as needed (lazily)...
        ///       i wish I knew of IoC "way" of wiring up repository getters...
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            dbContext = dbContextFactory.GetDbContext();
        }


        private readonly TeamRepository<Team2> _TeamRepository = null;


        //public TeamRepository<Team2> TeamRepository
        //{
        //    get { return _TeamRepository ?? (_TeamRepository = new TeamRepository<Team2>(dbContext)); }
        //}

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

 
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                  ///  dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}