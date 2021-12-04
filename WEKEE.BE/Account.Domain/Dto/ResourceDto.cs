using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypesRsc { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
