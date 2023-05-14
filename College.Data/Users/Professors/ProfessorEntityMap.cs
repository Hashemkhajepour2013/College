using College.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.Users.Professors
{
    public class ProfessorEntityMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.LastName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.FatherName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(_ => _.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(_ => _.ImageName).HasMaxLength(455).IsRequired(false);
            builder.Property(_ => _.UserName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.UsernameOfMaker).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.DegreeOfEducation).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.ContractType).IsRequired();
        }
    }
}
