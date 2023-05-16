using College.Common;
using College.Data.Repositories;
using College.Data.Users.Students.Contracts;
using College.Entities.Users;

namespace College.Data.Users.Students
{
    public class EFStudentRepository : Repository<Student>, IStudentRepository, IScopedDependency
    {
        public EFStudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
