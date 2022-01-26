using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AtomicId { get; set; }
        public string AtomicName { get; set; }
        public string Description { get; set; }
        public int? ActionBase { get; set; }
        public string ActionBaseName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
