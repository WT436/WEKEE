using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class ProcessUser
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IpUser { get; set; }
        public bool IsStatus { get; set; }
        public string Device { get; set; }
        public DateTime DateCreate { get; set; }
        public int? UserAccountId { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
