using Autofac;
using DI_Pattern_Autofac.Core.DbContext;
using DI_Pattern_Autofac.Core.Interfaces;
using DI_Pattern_Autofac.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core
{
    public class DataModule : Module
    {
        private string connStr;
        public DataModule(string connString)
        {
            this.connStr = connString;
        }

        public Northwind_DBEntities()
       : base("name=Northwind_DBEntities")
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this.connStr)).As<IDbContext>().InstancePerRequest();
            builder.RegisterType<EFContext>().InstancePerRequest();

            builder.RegisterType<SqlRepository>().As<IRepository>().InstancePerRequest();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
