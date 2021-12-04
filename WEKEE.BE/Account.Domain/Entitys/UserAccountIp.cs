using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class UserAccountIp
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public int IpUserAccount { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateCreate { get; set; }
        public int UpdateCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual UserAccount IpUserAccountNavigation { get; set; }
    }
}
