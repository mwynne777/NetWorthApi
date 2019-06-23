using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetWorth.Domain.Entities;

namespace NetWorth.Persistence.Configurations
{
    public class FactorIdentifierConfiguration : IEntityTypeConfiguration<FactorIdentifier>
    {
        public void Configure(EntityTypeBuilder<FactorIdentifier> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(e => e.Type).HasMaxLength(2);
        }
    }
}