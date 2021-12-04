using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class InfomationUser
    {
        public int Id { get; set; }
        public string Coordinates { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateCreate { get; set; }
        public int? UserAccountId { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
