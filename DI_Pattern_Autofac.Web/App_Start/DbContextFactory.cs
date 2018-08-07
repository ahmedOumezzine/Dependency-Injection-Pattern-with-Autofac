using DI_Pattern_Autofac.Core.Model;
using GRLibrary.ContextFactory;
using System.Data.Entity;

namespace DI_Pattern_Autofac.Web.App_Start
{
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Team2> TeamSet { get; set; }
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            // the context is new()ed up instead of being injected to avoid direct dependency on EF
            // not sure if this is good approach...but it removes direct dependency on EF from web tier
            if (_context == null) { _context = new Model1Container(); };
        }

        public DbContext GetDbContext()
        {
            return _context;
        }

        // see comment in IDbContextFactory inteface...
        //public void Dispose()
        //{
        //    if (_context != null)
        //    {
        //        _context.Dispose();
        //        GC.SuppressFinalize(this);
        //    }
        //}
    }
}