using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class HistoryTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRecord { get; set; }
        public string DataNew { get; set; }
        public string DataOld { get; set; }
        public int ActionRecord { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
