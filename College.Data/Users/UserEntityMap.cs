using College.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College.Data.Users
{
    public sealed class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.LastName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.FatherName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(_ => _.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(_ => _.ImageName).HasMaxLength(455).IsRequired(false);
            builder.Property(_ => _.UserName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.UsernameOfMaker).HasMaxLength(50).IsRequired();
        }
    }
}
