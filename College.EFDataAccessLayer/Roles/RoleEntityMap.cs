using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.EFDataAccessLayer.Roles;

public sealed class RoleEntityMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.Title).HasMaxLength(100).IsRequired();

        builder.HasMany(_ => _.UserRoles)
            .WithOne(_ => _.Role)
            .HasForeignKey(_ => _.RoleId);
    }
}