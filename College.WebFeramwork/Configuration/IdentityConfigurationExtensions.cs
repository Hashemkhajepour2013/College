using College.Data;
using College.Entities;
using College.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace College.WebFrameWork.Configuration
{
    public static class IdentityConfigurationExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services, IdentitySettings settings)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = settings.PasswordRequireDigit;

                options.Password.RequiredLength = settings.PasswordRequiredLength;

                options.Password.RequireNonAlphanumeric = settings.PasswordRequireNonAlphanumeric;

                options.Password.RequireUppercase = settings.PasswordRequireUppercase;

                options.Password.RequireLowercase = settings.PasswordRequireLowercase;

                options.User.RequireUniqueEmail = settings.RequireUniqueEmail;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
