using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class SubjectAssignmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int RoleId { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public bool IsCheck { get; set; }
    }
}
