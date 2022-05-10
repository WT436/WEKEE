using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.UserProfileDTO
{
    public class AuthenV2ReadDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string TokenId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
