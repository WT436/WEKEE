using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
