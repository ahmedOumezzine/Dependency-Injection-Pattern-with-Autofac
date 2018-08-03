using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using DI_Pattern_Autofac.Core;

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
            builder.RegisterModule(new DataModule(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\ahmed\source\repos\DI_Pattern_Autofac\DI_Pattern_Autofac.Web\App_Data\Database1.mdf;Integrated Security=True"));

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}