using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class ChangePasswordDtos
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; }
        public bool Remember { get; set; }
    }
}
