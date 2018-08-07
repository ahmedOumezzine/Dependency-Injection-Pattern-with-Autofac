﻿using System;

namespace GRLibrary
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        IGenericRepository<TEntity> GetNonGenericRepository<TEntity, TRepository>() where TEntity : class;

        void SaveChanges();
    }
}