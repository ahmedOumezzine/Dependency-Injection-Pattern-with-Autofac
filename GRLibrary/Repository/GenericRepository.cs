using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = entities.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
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

        public T FindBy(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = entities.Set<T>();
            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public Object SQL(String sqlquery)
        {
            return entities.Set<T>().SqlQuery(sqlquery);
        }

        public int Count(String ProductsTableName)
        {
            StringBuilder finalquery = new StringBuilder();
            finalquery.AppendFormat("SELECT count(*) FROM {0} ", ProductsTableName);
            return entities.Database.SqlQuery<int>(finalquery.ToString()).SingleOrDefault();
        }
    }
}