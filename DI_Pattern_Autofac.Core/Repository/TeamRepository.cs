using DI_Pattern_Autofac.Core.Model;
using GRLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DI_Pattern_Autofac.Core.Repository
{
    public class TeamRepository : IGenericRepository<Team2>, ITeamRepository
    {
        public TeamRepository(DbContext _entities)
        {
        }

        public void Add(Team2 entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Team2 entity)
        {
            throw new NotImplementedException();
        }

        public int Count(string ProductsTableName)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team2 entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Team2 entity)
        {
            throw new NotImplementedException();
        }

        public Team2 Find(object id)
        {
            throw new NotImplementedException();
        }

        public Team2 FindBy(Expression<Func<Team2, bool>> predicate, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Team2 Get(Expression<Func<Team2, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Team2> GetAll(Expression<Func<Team2, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<Team2> GetAll(Expression<Func<Team2, bool>> filter = null, Func<IQueryable<Team2>, IOrderedEnumerable<Team2>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public object SQL(string sqlquery)
        {
            throw new NotImplementedException();
        }

        int ITeamRepository.Count2(string ProductsTableName)
        {
            throw new NotImplementedException();
        }
    }
}