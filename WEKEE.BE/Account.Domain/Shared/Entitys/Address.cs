using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Address
    {
        public int Id { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? AccountId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
