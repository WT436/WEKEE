using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.AtomicDTO
{
    public class AtomicSummaryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypesRsc { get; set; }
    }
}
