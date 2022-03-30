using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductAttributeValue
    {
        public ProductAttributeValue()
        {
            ProductAttributeMappings = new HashSet<ProductAttributeMapping>();
        }

        public int Id { get; set; }
        public int Key { get; set; }
        public string Values { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductAttribute KeyNavigation { get; set; }
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }
    }
}
