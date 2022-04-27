using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Resource
    {
        public Resource()
        {
            ReourceAssignments = new HashSet<ReourceAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypesRsc { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<ReourceAssignment> ReourceAssignments { get; set; }
    }
}
