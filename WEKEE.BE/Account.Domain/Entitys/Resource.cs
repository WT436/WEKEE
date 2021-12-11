using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Resource
    {
        public Resource()
        {
            ResourceActions = new HashSet<ResourceAction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TypesRsc { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ResourceAction> ResourceActions { get; set; }
    }
}
