using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class AuthenticationInput
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
