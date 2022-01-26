using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Permission
    {
        public Permission()
        {
            ActionAssignments = new HashSet<ActionAssignment>();
            ConstraintAssignments = new HashSet<ConstraintAssignment>();
            PermissionAssignments = new HashSet<PermissionAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ActionAssignment> ActionAssignments { get; set; }
        public virtual ICollection<ConstraintAssignment> ConstraintAssignments { get; set; }
        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
