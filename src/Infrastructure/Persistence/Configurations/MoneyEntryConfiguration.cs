using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MoneyEntryConfiguration : IEntityTypeConfiguration<MoneyEntry>
    {
        public void Configure(EntityTypeBuilder<MoneyEntry> builder)
        {
            builder.HasOne(e => e.MoneyCategory).WithMany().HasForeignKey(e => e.MoneyCategoryId).IsRequired();
            builder.Property(e => e.Value).HasPrecision(9, 2);
            builder.Property(e => e.Details).HasMaxLength(200);
        }
    }
}
