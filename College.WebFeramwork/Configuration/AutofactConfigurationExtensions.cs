using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using College.Data.Roles.Contracts;
using College.Data.Roles;
using College.Data.Users.Contracts;
using College.Data.Users;
using College.Services.JWT.Contracts;
using College.Services.JWT;
using College.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using College.Common;
using College.Entities.Common;
using College.Data;
using College.Data.Repositories.Contracts;
using College.Data.Repositories;
using College.Services;

namespace College.WebFrameWork.Configuration
{
    public static class AutofactConfigurationExtensions
    {
        public static void AddService(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            var commonAssembly = typeof(SiteSettings).Assembly;
            var entitiesAssembly = typeof(IEntity).Assembly;
            var dataAssembly = typeof(ApplicationDbContext).Assembly;
            var serviceAssembly = typeof(JwtService).Assembly;

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, serviceAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces();
        }

        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);

            containerBuilder.AddService();

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
