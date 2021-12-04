using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class ForgotPasswordConfirmationTokenDtos
    {
        public string Account { get; set; }
        public string Token { get; set; }
        public string Ip { get; set; }
    }
}
