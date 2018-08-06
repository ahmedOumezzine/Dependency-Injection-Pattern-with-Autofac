using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using GRLibrary;

namespace DI_Pattern_Autofac.Web.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
           .WithParameter("dbContextFactory", new DbContextFactory())
           .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

           
        }
    }
}