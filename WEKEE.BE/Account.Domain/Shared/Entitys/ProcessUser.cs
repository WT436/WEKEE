using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class ProcessUser
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IpUser { get; set; }
        public bool IsStatus { get; set; }
        public string Device { get; set; }
        public int? AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
