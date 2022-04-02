using Domain.Common;

namespace Domain.Entities
{
    public class MoneyEntry : BaseEntity
    {
        public string Details { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        public int MoneyCategoryId { get; set; }
        public MoneyCategory MoneyCategory { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
