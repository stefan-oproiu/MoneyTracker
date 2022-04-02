using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class RowVersionEntity
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
