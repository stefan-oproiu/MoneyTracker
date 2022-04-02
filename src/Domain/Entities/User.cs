using Domain.Common;
using Domain.Misc;

namespace Domain.Entities
{
    public class User : RowVersionEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal MonthlyBudget { get; set; } = DomainConstants.DefaultMonthlyBudget;
        public string Currency { get; set; } = DomainConstants.DefaultCurrency;

        public ICollection<MoneyEntry> MoneyEntries { get; set; }
    }
}
