using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Persistence.Data
{
    public static class DefaultData
    {
        public static ICollection<MoneyCategory> SystemCategories = new List<MoneyCategory>
        {
            new MoneyCategory
            {
                Id = 1,
                Name = "Shopping",
                Icon = "shopping_cart",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 2,
                Name = "Food",
                Icon = "restaurant",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 3,
                Name = "Health",
                Icon = "health_and_safety",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 4,
                Name = "Education",
                Icon = "school",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 5,
                Name = "Bills & Utilities",
                Icon = "receipt_long",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 6,
                Name = "Transportation",
                Icon = "commute",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 7,
                Name = "Entertainment",
                Icon = "sports_esports",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 8,
                Name = "Donations",
                Icon = "volunteer_activism",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 9,
                Name = "Family",
                Icon = "family_restroom",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 10,
                Name = "Other",
                Icon = "public",
                Type = MoneyCategoryType.Expense
            },
            new MoneyCategory
            {
                Id = 11,
                Name = "Salary",
                Icon = "payments",
                Type = MoneyCategoryType.Income
            },
            new MoneyCategory
            {
                Id = 12,
                Name = "Sale",
                Icon = "sell",
                Type = MoneyCategoryType.Income
            },
            new MoneyCategory
            {
                Id = 13,
                Name = "Trading",
                Icon = "currency_exchange",
                Type = MoneyCategoryType.Income
            }
        };
    }
}
