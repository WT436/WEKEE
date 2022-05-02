using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.ResourceDTO
{
    public class FtPermissionReadDto : ResourceReadDto
    {
        public bool IsGranted { get; set; }
    }
}
