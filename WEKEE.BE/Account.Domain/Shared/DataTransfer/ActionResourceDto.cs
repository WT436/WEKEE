using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ActionResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AtomicName { get; set; }
        public string Description { get; set; }
        public string ActionBaseName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCheck { get; set; }
    }
}
