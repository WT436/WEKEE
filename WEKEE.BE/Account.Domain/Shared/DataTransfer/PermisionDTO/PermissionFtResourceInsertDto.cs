using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.PermisionDTO
{
    public class PermissionFtResourceInsertDto
    {
        public int Id { get; set; }

        public List<int> ResourceId { get; set; }
    }
}
