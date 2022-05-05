using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.UserProfileDTO
{
    public class AuthenticationResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Tokens { get; set; }
        public List<string> Roles { get; set; }
        public string Picture { get; set; }
        public string FullName { get; set; }
    }
}
