using DI_Pattern_Autofac.Core.Model;
using System;
namespace DI_Pattern_Autofac.Core.Interfaces
{
    public interface ITeamRepository : IRepository
    {
        System.Collections.Generic.List<User> GetUsersInTeam(int teamId);
    }
}
