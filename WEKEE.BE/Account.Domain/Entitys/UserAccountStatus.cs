using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class UserAccountStatus
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Code { get; set; }
        public int StatusId { get; set; }
        public string ReminderToken { get; set; }
        public int? ReminderExpire { get; set; }
        public int UpdateCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
