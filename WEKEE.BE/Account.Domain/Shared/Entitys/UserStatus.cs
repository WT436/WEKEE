using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class UserStatus
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
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
