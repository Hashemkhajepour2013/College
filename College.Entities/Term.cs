using College.Entities.Common;

namespace College.Entities
{
    public sealed class Term : BaseEntity
    {
        public string Title { get; set; }
        public byte UnitCount { get; set; }

        public ICollection<Classroom> Classrooms { get; set; } = new HashSet<Classroom>();
    }
}
