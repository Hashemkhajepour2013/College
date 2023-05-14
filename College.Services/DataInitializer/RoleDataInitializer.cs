using College.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace College.Services.DataInitializer
{
    public class RoleDataInitializer : IDataInitializer
    {
        private readonly SiteSettings _siteSetting;
        private readonly RoleManager<Role> _roleManager;

        public RoleDataInitializer(RoleManager<Role> roleManager, IOptionsSnapshot<SiteSettings> settings)
        {
            _roleManager = roleManager;
            _siteSetting = settings.Value;
        }

        public void InitializeData()
        {
            if(!_roleManager.Roles.AsNoTracking().Any())
            {
                foreach (var role in _siteSetting.Roles)
                {
                    _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }           
        }
    }
}
