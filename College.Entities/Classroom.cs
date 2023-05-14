using College.Entities.Common;

namespace College.Entities
{
    public sealed class Classroom : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Capacity { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int ProfessorId { get; set; }
        public User Professor { get; set; }
    }
}
