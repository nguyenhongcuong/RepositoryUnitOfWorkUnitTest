using System.Data.Entity;
using Autofac;
using ExampleDemo.Model;
using ExampleDemo.Repository.Common;

namespace ExampleDemo.Web.Modules
{
    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(ExampleDemoDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}