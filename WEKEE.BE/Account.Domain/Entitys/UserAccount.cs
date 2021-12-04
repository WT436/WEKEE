using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Addresses = new HashSet<Address>();
            InfomationUsers = new HashSet<InfomationUser>();
            ProcessUsers = new HashSet<ProcessUser>();
            Subjects = new HashSet<Subject>();
            UserAccountIps = new HashSet<UserAccountIp>();
        }

        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public int LoginFallNumber { get; set; }
        public DateTime? LockAccountTime { get; set; }
        public int StatusId { get; set; }
        public bool? IsOnline { get; set; }
        public int IsStatus { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual UserAccountStatus Status { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<InfomationUser> InfomationUsers { get; set; }
        public virtual ICollection<ProcessUser> ProcessUsers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<UserAccountIp> UserAccountIps { get; set; }
    }
}
