using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.RoleDTO
{
    public class RoleReadDto
    {
        public int Id { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int RoleManageId { get; set; }
        public string RoleManageName { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
