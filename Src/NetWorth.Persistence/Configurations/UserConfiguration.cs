using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetWorth.Domain.Entities;

namespace NetWorth.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(e => e.FirstName).HasMaxLength(20);

            builder.Property(e => e.LastName).HasMaxLength(20);

            builder.Property(e => e.UserName).HasMaxLength(20);

            builder.Property(e => e.Password).HasMaxLength(20);
        }
    }
}