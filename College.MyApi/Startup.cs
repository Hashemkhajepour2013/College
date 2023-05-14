using Autofac;
using College.Services;
using College.WebFrameWork.Configuration;
using College.WebFrameWork.CustomMapping;
using College.WebFrameWork.Swagger;
using College.WebFrameWork.Middleware;

namespace College.MyApi
{
    public class Startup
    {
        private readonly SiteSettings _siteSettings;

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
            
            _siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
                 
            services.InitializeAutoMapper();

            services.AddCors(options =>
            {
                options.AddPolicy("mainCors", policy =>
                {
                    policy.WithOrigins(new string[] { "http://localhost:8080" , "https://localhost:7150" }).AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddDbContext(Configuration);

            services.AddCustomIdentity(_siteSettings.identitySettings);

            services.AddMinimalMvc();

            services.AddJwtAuthentication(_siteSettings.jwtSettings);

            services.AddCustomApiVersioning();

            services.AddSwagger();    
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.IntializeDatabase();

            app.UseCustomExceptionHandler();

            app.UseCors("mainCors");

            app.UseHsts(env);

            app.UseHttpsRedirection();

            app.UseSwaggerAndUI();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });
        }
    }
}
