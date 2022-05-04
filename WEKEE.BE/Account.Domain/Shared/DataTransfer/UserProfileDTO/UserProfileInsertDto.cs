using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.UserProfileDTO
{
    public class UserProfileInsertDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public bool IsAcceptTerm { get; set; }
        public string Address { get; set; }
    }
}
