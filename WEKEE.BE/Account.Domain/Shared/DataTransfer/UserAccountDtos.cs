using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class UserAccountDtos
    {
        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Picture { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
