using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ActionAssignmentDto
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string NameAtomic { get; set; }
        public int? ActionBase { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCheck { get; set; }
    }
}
