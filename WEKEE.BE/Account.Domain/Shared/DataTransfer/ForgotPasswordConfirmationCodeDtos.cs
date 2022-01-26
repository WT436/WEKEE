using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ForgotPasswordConfirmationCodeDtos
    {
        public string Account { get; set; }
        public string Code { get; set; }
        public string Ip { get; set; }
    }
}
