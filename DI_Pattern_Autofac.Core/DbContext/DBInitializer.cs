using DI_Pattern_Autofac.Core.Model;
using DI_Pattern_Autofac.Core.Repository;
using System.Data.Entity;


namespace DI_Pattern_Autofac.Core.DbContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
    
        }
    }
}
