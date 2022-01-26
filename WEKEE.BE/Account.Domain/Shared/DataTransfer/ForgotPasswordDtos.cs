using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ForgotPasswordDtos
    {
        public string Account { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Ip { get; set; }
    }
}
