using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class ResourceAction
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int ActionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Action Action { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
