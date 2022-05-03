using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.SubjectDTO
{
    public class SubjectFtRoleInsertDto
    {
        public int Id { get; set; }

        public List<int> RoleId { get; set; }
    }
}
