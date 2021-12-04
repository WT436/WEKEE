using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Group
    {
        public Group()
        {
            SubjectGroups = new HashSet<SubjectGroup>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string NameGroup { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Introduce { get; set; }
        public string GroupType { get; set; }
        public string LinkedPages { get; set; }
        public string MembershipApproval { get; set; }
        public string PostApproval { get; set; }
        public string Tags { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
