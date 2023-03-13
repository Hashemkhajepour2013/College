using College.Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace College.WebFramework.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            Assert.NotNull(services, nameof(services));
            services.AddSwaggerGen(option =>
            {
                var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "College.WebAPI.xml");

                option.IncludeXmlComments(xmlDocPath, true);

                option.EnableAnnotations();

                option.DescribeAllParametersInCamelCase();

                option.SwaggerDoc("v1", new OpenApiInfo {Version = "v1" , Title = "College.WebAPI"});

                option.OperationFilter<RemoveVersionParameters>();

                option.DocumentFilter<SetVersionInPaths>();

                option.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v}" == docName);
                });
            });
        }

        public static IApplicationBuilder UseSwaggerAndUI(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
