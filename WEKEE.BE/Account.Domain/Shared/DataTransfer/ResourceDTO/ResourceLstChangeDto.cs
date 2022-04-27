using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.ResourceDTO
{
    public class ResourceLstChangeDto
    {
       public List<int> Ids { get; set; }
       public int Types { get; set; }
    }
}
