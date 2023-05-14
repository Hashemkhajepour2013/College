using College.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace College.Entities
{
    public class Role : IdentityRole<int>, IEntity
    {
        public string Description { get; set; }
    }
}
