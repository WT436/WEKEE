using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class Permission
    {
        public Permission()
        {
            InversePermissionNavigation = new HashSet<Permission>();
            PermissionAssignments = new HashSet<PermissionAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AtomicId { get; set; }
        public int ResourceManageId { get; set; }
        public int LevelPermition { get; set; }
        public int PermissionId { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Atomic Atomic { get; set; }
        public virtual Permission PermissionNavigation { get; set; }
        public virtual Resource ResourceManage { get; set; }
        public virtual ICollection<Permission> InversePermissionNavigation { get; set; }
        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
