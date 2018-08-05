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


            // Register our Data dependencies
            //builder.RegisterModule(new DataModule(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\ahmed\source\repos\DI_Pattern_Autofac\DI_Pattern_Autofac.Web\App_Data\Database1.mdf;Integrated Security=True"));
            //  builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
           .WithParameter("dbContextFactory", new DbContextFactory())
           .InstancePerHttpRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

           
        }
    }
}