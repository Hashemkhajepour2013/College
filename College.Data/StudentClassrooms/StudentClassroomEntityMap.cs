using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.StudentClassrooms
{
    public class StudentClassroomEntityMap : IEntityTypeConfiguration<StudentClassroom>
    {
        public void Configure(EntityTypeBuilder<StudentClassroom> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();

            builder.HasOne(_ => _.Student)
                .WithMany(_ => _.StudentClassrooms)
                .HasForeignKey(_ => _.StudentId);

            builder.HasOne(_ => _.classroom)
                .WithMany(_ => _.StudentClassrooms)
                .HasForeignKey(_ => _.ClassroomId);
        }
    }
}
