using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GRLibrary
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Find(object id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        void Attach(T entity);
    }
}
