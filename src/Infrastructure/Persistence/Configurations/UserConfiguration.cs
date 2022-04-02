using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.HasMany(u => u.MoneyEntries).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
            builder.Property(u => u.MonthlyBudget).HasPrecision(9, 2);
        }
    }
}
