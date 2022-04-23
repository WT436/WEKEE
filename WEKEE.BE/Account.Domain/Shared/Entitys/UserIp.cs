using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class UserIp
    {
        public int Id { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string UserAgent { get; set; }
        public int AccountId { get; set; }
        public int UpdateAcount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
