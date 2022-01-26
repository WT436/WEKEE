using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class ConstraintAssignment
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int AuthorizationConstraintId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual AuthorizationConstraint AuthorizationConstraint { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
