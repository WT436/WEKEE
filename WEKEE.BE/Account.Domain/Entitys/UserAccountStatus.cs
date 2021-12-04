using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class UserAccountStatus
    {
        public UserAccountStatus()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string ReminderToken { get; set; }
        public int? ReminderExpire { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateCreate { get; set; }
        public int UpdateCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
