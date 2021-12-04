using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelRole { get; set; }
        public int RoleId { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
