using College.Common.Utilities;
using College.Data;
using College.Services.DataInitializer;
using College.WebFrameWork.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.WebFrameWork.Configuration
{
    public static class ApplicationBuilder
    {
        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            Assert.NotNull(app, nameof(app));
            Assert.NotNull(env, nameof(env));

            if (!env.IsDevelopment())
                app.UseHsts();

            return app;
        }

        public static IApplicationBuilder IntializeDatabase(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));

            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Database.Migrate();

            var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
            foreach (var dataInitializer in dataInitializers)
                dataInitializer.InitializeData();

            return app;
        }
    }
}
