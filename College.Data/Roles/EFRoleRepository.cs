using College.Common;
using College.Data.Repositories;
using College.Data.Roles.Contracts;
using College.Entities;

namespace College.Data.Roles
{
    public class EFRoleRepository : Repository<Role>, IRoleRepository, IScopedDependency
    {
        public EFRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
