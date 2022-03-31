using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class CategoryProduct
    {
        public CategoryProduct()
        {
            InverseCategoryMainNavigation = new HashSet<CategoryProduct>();
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
            SpecificationAttributes = new HashSet<SpecificationAttribute>();
        }

        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public int? IconCategory { get; set; }
        public int LevelCategory { get; set; }
        public int? CategoryMain { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual CategoryProduct CategoryMainNavigation { get; set; }
        public virtual ImageProduct IconCategoryNavigation { get; set; }
        public virtual ICollection<CategoryProduct> InverseCategoryMainNavigation { get; set; }
        public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual ICollection<SpecificationAttribute> SpecificationAttributes { get; set; }
    }
}
