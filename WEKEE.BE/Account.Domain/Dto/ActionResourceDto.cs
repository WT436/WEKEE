using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class ActionResourceDto
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCheck { get; set; }

    }
}
