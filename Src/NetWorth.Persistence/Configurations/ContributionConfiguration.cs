using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetWorth.Domain.Entities;

namespace NetWorth.Persistence.Configurations
{
    public class ContributionConfiguration : IEntityTypeConfiguration<Contribution>
    {
        public void Configure(EntityTypeBuilder<Contribution> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(20);

            builder.Property(e => e.Amount).HasColumnType("money");

            builder.Property(e => e.FactorID);

            /*builder.HasOne(d => d.Factor)
                .WithMany(p => p.Contributions)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_Contributions_Factors");*/

            /*builder.HasOne(a => a.FactorID)
                .WithOne();*/
        }
    }
}