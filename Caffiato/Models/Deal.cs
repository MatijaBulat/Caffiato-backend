using System;
using System.Collections.Generic;

namespace Caffiato.Models
{
    public partial class Deal
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public int CaffeId { get; set; }
        public bool? Active { get; set; }

        [JsonIgnore]
        public virtual Caffe Caffe { get; set; } = null!;
    }
}
