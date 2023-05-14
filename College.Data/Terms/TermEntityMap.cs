using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.Terms
{
    public sealed class TermEntityMap : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Title).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.UnitCount).IsRequired();
        }
    }
}
