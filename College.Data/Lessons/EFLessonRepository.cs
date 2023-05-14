using College.Common;
using College.Data.Lessons.Contracts;
using College.Data.Repositories;
using College.Entities;

namespace College.Data.Lessons
{
    public class EFLessonRepository : Repository<Lesson>, ILessonRepository, IScopedDependency
    {
        public EFLessonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
