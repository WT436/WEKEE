using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
            ProductSpecificationAttributeMappings = new HashSet<ProductSpecificationAttributeMapping>();
            ProductTrademarkNavigations = new HashSet<Product>();
            ProductUnitProductNavigations = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Types { get; set; }
        public int? CategoryProductId { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
        public virtual ICollection<Product> ProductTrademarkNavigations { get; set; }
        public virtual ICollection<Product> ProductUnitProductNavigations { get; set; }
    }
}
