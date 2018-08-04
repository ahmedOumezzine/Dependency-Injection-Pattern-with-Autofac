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
 
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext()).As<IDbContext>().InstancePerRequest();
            builder.RegisterType<EFContext>().InstancePerRequest();

           // builder.RegisterType<SqlRepository>().As<IRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
