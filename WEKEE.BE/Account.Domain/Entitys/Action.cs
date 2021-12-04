using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Action
    {
        public Action()
        {
            ActionAssignments = new HashSet<ActionAssignment>();
            InverseActionBaseNavigation = new HashSet<Action>();
            ResourceActions = new HashSet<ResourceAction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AtomicId { get; set; }
        public string Description { get; set; }
        public int? ActionBase { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Action ActionBaseNavigation { get; set; }
        public virtual Atomic Atomic { get; set; }
        public virtual ICollection<ActionAssignment> ActionAssignments { get; set; }
        public virtual ICollection<Action> InverseActionBaseNavigation { get; set; }
        public virtual ICollection<ResourceAction> ResourceActions { get; set; }
    }
}
