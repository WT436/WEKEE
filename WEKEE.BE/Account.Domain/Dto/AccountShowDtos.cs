using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class AccountShowDtos
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Gender { get; set; }
        public int? IsStattus { get; set; }
        public string Role { get; set; }
    }
}
