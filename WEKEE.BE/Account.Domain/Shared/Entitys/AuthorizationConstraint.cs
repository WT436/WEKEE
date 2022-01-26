using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class AuthorizationConstraint
    {
        public AuthorizationConstraint()
        {
            ConstraintAssignments = new HashSet<ConstraintAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ConstraintAssignment> ConstraintAssignments { get; set; }
    }
}
