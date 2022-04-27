using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.ResourceDTO
{
    public class ResourceReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypesRsc { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
