using College.Common;
using College.Data.Repositories;
using College.Entities;

namespace College.Data.Classrooms.Contracts
{
    public sealed class EFClassroomRepository : Repository<Classroom>, IClassroomRepository, IScopedDependency
    {
        public EFClassroomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
