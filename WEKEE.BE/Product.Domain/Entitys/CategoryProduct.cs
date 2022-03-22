using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class CategoryProduct
    {
        public CategoryProduct()
        {
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
        }

        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public string IconCategory { get; set; }
        public int LevelCategory { get; set; }
        public int? CategoryMain { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
    }
}
