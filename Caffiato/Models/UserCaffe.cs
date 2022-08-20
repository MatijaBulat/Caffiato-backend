using System;
using System.Collections.Generic;

namespace Caffiato.Models
{
    public partial class UserCaffe
    {
        public UserCaffe()
        {
            Caffes = new HashSet<Caffe>();
            Transacts = new HashSet<Transact>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Username { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Oib { get; set; }
        public int Points { get; set; }

        public virtual ICollection<Caffe> Caffes { get; set; }
        public virtual ICollection<Transact> Transacts { get; set; }
    }
}
