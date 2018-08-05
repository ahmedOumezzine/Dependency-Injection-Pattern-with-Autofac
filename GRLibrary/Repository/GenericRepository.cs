using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GRLibrary
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {

        private DbContext entities = null;

        public GenericRepository(DbContext _entities)
        {
            entities = _entities;
        }


        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return entities.Set<T>().Where(predicate);
            }

            return entities.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return entities.Set<T>().FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            entities.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entities.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            entities.SaveChanges();
        }

        public void Attach(T entity)
        {
            entities.Set<T>().Attach(entity);
        }

        public T Find(object id)
        {
            return entities.Set<T>().Find(id);
        }
    }
}