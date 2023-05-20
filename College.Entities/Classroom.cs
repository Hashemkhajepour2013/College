using College.Entities.Common;
using College.Entities.Users;

namespace College.Entities
{
    public class Classroom : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Capacity { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public List<StudentClassroom> StudentClassrooms { get; set; } = new();
    }
}
