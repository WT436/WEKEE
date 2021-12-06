using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class CategoryProduct
    {
        public CategoryProduct()
        {
            Products = new HashSet<Product>();
            SpecificationsCategories = new HashSet<SpecificationsCategory>();
        }

        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public string IconCategory { get; set; }
        public int LevelCategory { get; set; }
        public int? CategoryMain { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEnd { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SpecificationsCategory> SpecificationsCategories { get; set; }
    }
}
