using DI_Pattern_Autofac.Core.Interfaces;
using DI_Pattern_Autofac.Core.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DI_Pattern_Autofac.Core.DbContext
{
    public class EFContext : System.Data.Entity.DbContext, IDbContext
    {
        public EFContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<EFContext>(new DBInitializer());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();

        }

        public EFContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<Team>();
            modelBuilder.Entity<Log>();
            base.OnModelCreating(modelBuilder);
        }
    }
}