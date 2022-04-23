using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Atomic
    {
        public Atomic()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypesRsc { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
