using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer
{
    public class RoleAuthDtos
    {
        public int Id { get; set; }
        public int LevelRole { get; set; }
        public string NameResource { get; set; }
        public string TypesRsc { get; set; }
        public string NameAtomic { get; set; }
    }
}
