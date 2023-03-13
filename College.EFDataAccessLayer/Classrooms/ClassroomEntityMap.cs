using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.EFDataAccessLayer.Classrooms
{
    public sealed class ClassroomEntityMap : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.LessonId).IsRequired();
            builder.Property(_ => _.ProfessorId).IsRequired();
            builder.Property(_ => _.StartDate).IsRequired();
            builder.Property(_ => _.EndDate).IsRequired();
            builder.Property(_ => _.Capacity).IsRequired();
        }
    }
}
