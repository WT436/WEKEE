using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int RoleId { get; set; }
        public string RoleMainName { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
