using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.Classrooms
{
    public sealed class ClassroomEntityMap : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.ProfessorId).IsRequired();
            builder.Property(_ => _.StartDate).IsRequired();
            builder.Property(_ => _.EndDate).IsRequired();
            builder.Property(_ => _.Capacity).IsRequired();

            builder.HasOne(_ => _.Term)
                .WithMany(_ => _.Classrooms)
                .HasForeignKey(_ => _.TermId);

            builder.HasOne(_ => _.Lesson)
                .WithMany(_ => _.Classrooms)
                .HasForeignKey(_ => _.LessonId);

            builder.HasOne(_ => _.Professor)
                .WithMany(_ => _.Classrooms)
                .HasForeignKey(_ => _.ProfessorId);
        }
    }
}
