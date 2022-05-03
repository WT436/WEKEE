using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.RoleDTO
{
    public class SubjectFtRoleReadDto : RoleReadDto
    {
        public bool IsGranted { get; set; }
    }
}
