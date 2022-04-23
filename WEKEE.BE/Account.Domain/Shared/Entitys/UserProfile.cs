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
            UserIps = new HashSet<UserIp>();
            UserPasswords = new HashSet<UserPassword>();
            UserStatuses = new HashSet<UserStatus>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public bool? IsOnline { get; set; }
        public int IsStatus { get; set; }
        public int LoginFallNumber { get; set; }
        public DateTime? LockAccountTime { get; set; }
        public bool IsAcceptTerm { get; set; }
        public string TimeZone { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string ZaloId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<InfomationUser> InfomationUsers { get; set; }
        public virtual ICollection<ProcessUser> ProcessUsers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<UserIp> UserIps { get; set; }
        public virtual ICollection<UserPassword> UserPasswords { get; set; }
        public virtual ICollection<UserStatus> UserStatuses { get; set; }
    }
}
