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
            builder.Property(_ => _.DegreeOfEducation).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.ContractType).IsRequired();
        }
    }
}
