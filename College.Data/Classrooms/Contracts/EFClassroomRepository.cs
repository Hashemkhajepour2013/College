using College.Common;
using College.Data.Repositories;
using College.Entities;
using College.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace College.Data.Classrooms.Contracts
{
    public sealed class EFClassroomRepository : Repository<Classroom>, IClassroomRepository, IScopedDependency
    {
        public EFClassroomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Classroom>> GetByGrade(Grade grade)
        {
            return await TableNoTracking.Where(_ => _.Grade == grade).ToListAsync();
        }
    }
}
