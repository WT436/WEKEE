using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.UserProfileDTO
{
    public class UserProfileLoginReadDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsOnline { get; set; }
        public int IsStatus { get; set; }
        public int LoginFallNumber { get; set; }
        public DateTime LockAccountTime { get; set; }
        public string TimeZone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public int Gender { get; set; }
    }
}
