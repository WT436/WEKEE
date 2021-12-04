using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AtomicId { get; set; }
        public string NameAtomic { get; set; }
        public string Description { get; set; }
        public int? ActionBase { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsActive { get; set; }
    }
}
