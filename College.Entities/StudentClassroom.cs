using College.Entities.Common;
using College.Entities.Users;

namespace College.Entities
{
    public class StudentClassroom : BaseEntity
    {
        public int ClassroomId { get; set; }
        public Classroom classroom { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
