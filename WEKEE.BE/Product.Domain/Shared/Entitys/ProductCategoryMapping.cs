using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductCategoryMapping
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual CategoryProduct Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
