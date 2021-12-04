using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class SubjectGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GorupId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual Group Gorup { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
