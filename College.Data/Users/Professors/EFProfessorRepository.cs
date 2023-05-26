using College.Common;
using College.Data.Repositories;
using College.Data.Users.Professors.Contracts;
using College.Entities.Users;

namespace College.Data.Users.Professors
{
    public class EFProfessorRepository : Repository<Professor>, IProfessorRepository, IScopedDependency
    {
        public EFProfessorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
