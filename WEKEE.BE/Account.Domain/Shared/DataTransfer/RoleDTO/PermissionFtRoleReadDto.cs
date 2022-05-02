using Account.Domain.Shared.DataTransfer.PermisionDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.RoleDTO
{
    public class PermissionFtRoleReadDto : PermissionReadDto
    {
        public bool IsGranted { get; set; }
    }
}
