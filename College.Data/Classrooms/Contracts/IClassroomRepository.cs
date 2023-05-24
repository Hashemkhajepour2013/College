using College.Data.Repositories.Contracts;
using College.Entities;
using College.Entities.Common;

namespace College.Data.Classrooms.Contracts
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        Task<List<Classroom>> GetByGrade(Grade grade);
    }
}
