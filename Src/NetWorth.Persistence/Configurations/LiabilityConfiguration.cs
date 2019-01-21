using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetWorth.Domain.Entities;

namespace NetWorth.Persistence.Configurations
{
    public class LiabilityConfiguration : IEntityTypeConfiguration<Liability>
    {
        public void Configure(EntityTypeBuilder<Liability> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(e => e.Name).HasMaxLength(20);

            builder.Property(e => e.CurrentValue).HasColumnType("money");

            builder.Property(e => e.HasInterest).HasMaxLength(1);

            builder.Property(e => e.InterestRate).HasColumnType("decimal");

            builder.Property(e => e.Type).HasMaxLength(2);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Liabilities)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_Liabilities_Users");
        }
    }
}