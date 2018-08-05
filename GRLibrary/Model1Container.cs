using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRLibrary
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
}
