using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool AcceptTermOfService { get; set; }
        public string TimeZone { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string ZaloId { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
