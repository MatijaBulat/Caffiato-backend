using System;
using System.Collections.Generic;

namespace Caffiato.Models
{
    public partial class Transact
    {
        public int Idtransaction { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public int UserCaffeId { get; set; }

        [JsonIgnore]
        public virtual UserCaffe UserCaffe { get; set; } = null!;
    }
}
