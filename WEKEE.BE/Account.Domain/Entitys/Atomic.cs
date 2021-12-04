using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Atomic
    {
        public Atomic()
        {
            Actions = new HashSet<Action>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
