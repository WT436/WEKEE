using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class PermissionAssignmentDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCheck { get; set; }
    }
}
