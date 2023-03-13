using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.EFDataAccessLayer.Terms
{
    public sealed class TermEntityMap : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Title).IsRequired();

            builder.HasMany(_ => _.Classrooms)
                .WithOne(_ => _.Term)
                .HasForeignKey(_ => _.TermId);
        }
    }
}
