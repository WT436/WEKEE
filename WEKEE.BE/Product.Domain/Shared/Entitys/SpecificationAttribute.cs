using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class SpecificationAttribute
    {
        public SpecificationAttribute()
        {
            ProductSpecificationAttributeMappings = new HashSet<ProductSpecificationAttributeMapping>();
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public int CategoryProductId { get; set; }
        public string GroupSpecification { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }
        public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
    }
}
