using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ActionResourceUpdateDto
    {
        public int Id { get; set; }
        public bool IsResource { get; set; }
        public List<string> DataUpdate { get; set; }
    }
}
