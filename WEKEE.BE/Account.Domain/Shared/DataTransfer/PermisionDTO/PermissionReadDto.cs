using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.PermisionDTO
{
    public class PermissionReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AtomicId { get; set; }
        public string AtomicName { get; set; }
        public int LevelPermition { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
