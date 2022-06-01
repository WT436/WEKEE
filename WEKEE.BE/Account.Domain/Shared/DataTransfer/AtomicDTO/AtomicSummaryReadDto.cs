using Account.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.AtomicDTO
{
    public class AtomicSummaryReadDto : EntityKey<int>
    {
        public string Name { get; set; }
        public int TypesRsc { get; set; }
    }
}
