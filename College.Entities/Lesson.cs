using College.Entities.Common;

namespace College.Entities
{
    public sealed class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public byte Coefficient { get; set; }

        public ICollection<Classroom> Classrooms { get; set; } = new HashSet<Classroom>();
    }
}
