using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Role
    {
        public Role()
        {
            InverseRoleNavigation = new HashSet<Role>();
            PermissionAssignments = new HashSet<PermissionAssignment>();
            SubjectAssignments = new HashSet<SubjectAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int? RoleId { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Role> InverseRoleNavigation { get; set; }
        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
        public virtual ICollection<SubjectAssignment> SubjectAssignments { get; set; }
    }
}
