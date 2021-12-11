using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class InfomationUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Coordinates { get; set; }
        public string Picture { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
