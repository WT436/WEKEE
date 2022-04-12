using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductSpecificationAttributeMapping
    {
        public int Id { get; set; }
        public string CustomValue { get; set; }
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public int? AttributeTypeId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductAttribute AttributeType { get; set; }
        public virtual Product Product { get; set; }
        public virtual SpecificationAttribute Specification { get; set; }
    }
}
