using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.RoleDTO
{
    public class RoleFtPermissionInsertDto
    {
        public int Id { get; set; }

        public List<int> PermissionId { get; set; }
    }
}
