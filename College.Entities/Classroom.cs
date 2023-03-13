namespace College.Entities
{
    public sealed class Classroom : BaseEntity
    {
        public int LessonId { get; set; }
        public int ProfessorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Capacity { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }
    }
}
