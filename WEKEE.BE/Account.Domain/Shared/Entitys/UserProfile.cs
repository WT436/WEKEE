using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Addresses = new HashSet<Address>();
            InfomationUsers = new HashSet<InfomationUser>();
            ProcessUsers = new HashSet<ProcessUser>();
            Subjects = new HashSet<Subject>();
            UserAccountIps = new HashSet<UserAccountIp>();
            UserAccountStatuses = new HashSet<UserAccountStatus>();
        }

        public int Id { get; set; }
        public bool IsAcceptTerm { get; set; }
        public string TimeZone { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string ZaloId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserLogin UserLogin { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<InfomationUser> InfomationUsers { get; set; }
        public virtual ICollection<ProcessUser> ProcessUsers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<UserAccountIp> UserAccountIps { get; set; }
        public virtual ICollection<UserAccountStatus> UserAccountStatuses { get; set; }
    }
}
