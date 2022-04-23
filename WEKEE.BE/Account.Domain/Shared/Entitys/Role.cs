using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Role
    {
        public Role()
        {
            InverseRoleManage = new HashSet<Role>();
            PermissionAssignments = new HashSet<PermissionAssignment>();
            SubjectAssignments = new HashSet<SubjectAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int RoleManageId { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Role RoleManage { get; set; }
        public virtual ICollection<Role> InverseRoleManage { get; set; }
        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
        public virtual ICollection<SubjectAssignment> SubjectAssignments { get; set; }
    }
}
