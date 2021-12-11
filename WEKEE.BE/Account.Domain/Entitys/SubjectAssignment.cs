using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class SubjectAssignment
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int SubjectId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Role Role { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
