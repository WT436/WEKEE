using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int LoginFallNumber { get; set; }
        public DateTime? LockAccountTime { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public bool? IsOnline { get; set; }
        public int IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserProfile IdNavigation { get; set; }
    }
}
