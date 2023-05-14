using AutoMapper;
using College.Data;
using College.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace College.WebFrameWork.CustomMapping
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(config => { config.AddCustomMappingProfile(); }, assemblies);
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
        {
            var dataAssembly = typeof(ApplicationDbContext).Assembly;
            config.AddCustomMappingProfile(dataAssembly);
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config,
            params Assembly[] assemblies)
        {
            var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
                .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            var profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }
    }
}