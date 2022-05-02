using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.PermisionDTO
{
    public class PermissionFtReourceReadDto
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
