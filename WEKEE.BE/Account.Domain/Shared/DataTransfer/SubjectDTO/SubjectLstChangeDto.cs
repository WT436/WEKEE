using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.SubjectDTO
{
    public class SubjectLstChangeDto
    {
        public List<int> Ids { get; set; }
        public int Types { get; set; }
    }
}
