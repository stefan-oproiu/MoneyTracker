using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class MoneyCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public MoneyCategoryType Type { get; set; }
    }
}
