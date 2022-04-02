using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MoneyCategoryConfiguration : IEntityTypeConfiguration<MoneyCategory>
    {
        public void Configure(EntityTypeBuilder<MoneyCategory> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(30);
            builder.HasData(DefaultData.SystemCategories);
        }
    }
}
