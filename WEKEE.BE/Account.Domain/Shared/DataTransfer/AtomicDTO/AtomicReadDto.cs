using Account.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.AtomicDTO
{
    public class AtomicReadDto:EntityKey<int>
    {
        public string Name { get; set; }
        public int TypesRsc { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
