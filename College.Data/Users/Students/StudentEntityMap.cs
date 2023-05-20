using College.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.Users.Students
{
    public class StudentEntityMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.EntryDate).IsRequired();
            builder.Property(_ => _.GraduationDate).IsRequired(false);
            builder.Property(_ => _.State).IsRequired();
            builder.Property(_ => _.Grade).IsRequired();
            builder.Property(_ => _.ConditionalSemesters).IsRequired();
            builder.Property(_ => _.SemestersTaken).IsRequired();
        }
    }
}
