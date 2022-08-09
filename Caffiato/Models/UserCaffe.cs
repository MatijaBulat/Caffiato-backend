﻿using System;
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

        public int IduserCaffe { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Oib { get; set; }
        public int Points { get; set; }

        public virtual ICollection<Caffe> Caffes { get; set; }
        public virtual ICollection<Transact> Transacts { get; set; }
    }
}
