using System;
using System.Collections.Generic;

namespace Caffiato.Models
{
    public partial class Caffe
    {
        public Caffe()
        {
            Addresses = new HashSet<Address>();
            Deals = new HashSet<Deal>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserCaffeId { get; set; }

        [JsonIgnore]
        public virtual UserCaffe UserCaffe { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
