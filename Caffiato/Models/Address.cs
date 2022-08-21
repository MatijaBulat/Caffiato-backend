using System;
using System.Collections.Generic;

namespace Caffiato.Models
{
    public partial class Address
    {
        public int Idaddress { get; set; }
        public string StreetNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostCode { get; set; }
        public int CaffeId { get; set; }

        [JsonIgnore]
        public virtual Caffe Caffe { get; set; } = null!;
    }
}
