using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DI_Pattern_Autofac.Core.Interfaces;
using DI_Pattern_Autofac.Core.Model;


namespace DI_Pattern_Autofac.Core.Repository
{
    public class TeamRepository : SqlRepository, ITeamRepository
    {
        public TeamRepository(IDbContext context)
            : base(context)
        {

        }
        public List<User> GetUsersInTeam(int teamId)
        {
            return (from u in this.GetAll<User>()
                    where u.TeamId == teamId
                    select u).ToList();
        }
    }
}
