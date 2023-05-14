using Autofac;
using College.Common;
using College.Data;
using College.Data.Repositories;
using College.Data.Repositories.Contracts;
using College.Entities.Common;
using College.Services.DataInitializer;

namespace College.WebFrameWork.Configuration
{
    public static class ServicesDependencies
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            var entitiesAssembly = typeof(IEntity).Assembly;
            var entityAssembly = typeof(ApplicationDbContext).Assembly;
            var dataAssembly = typeof(IDataInitializer).Assembly;

            containerBuilder.RegisterAssemblyTypes(entitiesAssembly, entityAssembly, dataAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
