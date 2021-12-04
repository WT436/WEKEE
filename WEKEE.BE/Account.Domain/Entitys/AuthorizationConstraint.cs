using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class AuthorizationConstraint
    {
        public AuthorizationConstraint()
        {
            ConstraintAssignments = new HashSet<ConstraintAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ConstraintAssignment> ConstraintAssignments { get; set; }
    }
}
