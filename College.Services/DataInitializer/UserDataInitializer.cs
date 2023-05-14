using College.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace College.Services.DataInitializer
{
    public class UserDataInitializer : IDataInitializer
    {
        private readonly SiteSettings _siteSetting;
        private readonly UserManager<User> _userManager;

        public UserDataInitializer(UserManager<User> userManager, IOptionsSnapshot<SiteSettings> settings)
        {
            _userManager = userManager;
            _siteSetting = settings.Value;
        }

        public void InitializeData()
        {
            if (!_userManager.Users.AsNoTracking().Any())
            {
                foreach (var user in _siteSetting.Users)
                {
                    var Userdb = new Student
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Mobile = user.Mobile,
                        FatherName = user.FatherName,
                        NationalCode = user.NationalCode,
                        ImageName = Guid.NewGuid().ToString(),
                        UserName = user.UserName,
                        UsernameOfMaker = user.UsernameOfMaker,
                        Email = user.Email
                    };

                    _userManager.CreateAsync(Userdb, user.Password).GetAwaiter().GetResult();

                    _userManager.AddToRoleAsync(Userdb, user.RoleName).GetAwaiter().GetResult();
                }
            }
        }
    }
}
