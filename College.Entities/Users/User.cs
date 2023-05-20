using College.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace College.Entities.Users
{
    public class User : IdentityUser<int>, IEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string ImageName { get; set; }
        public string UsernameOfMaker { get; set; }
    }
}
