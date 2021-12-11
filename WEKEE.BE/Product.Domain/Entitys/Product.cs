using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class Product
    {
        public Product()
        {
            DescriptionProducts = new HashSet<DescriptionProduct>();
            FeatureProducts = new HashSet<FeatureProduct>();
            HighlightProducts = new HashSet<HighlightProduct>();
            ImageProducts = new HashSet<ImageProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UnitProduct { get; set; }
        public bool? Fragile { get; set; }
        public string Origin { get; set; }
        public int? Trademark { get; set; }
        public string Introduce { get; set; }
        public string Tag { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsStatus { get; set; }
        public bool IsEnabled { get; set; }
        public int? Supplier { get; set; }
        public int? CategoryProduct { get; set; }
        public string ProductAlbum { get; set; }
        public int? Seo { get; set; }

        public virtual CategoryProduct CategoryProductNavigation { get; set; }
        public virtual Seo SeoNavigation { get; set; }
        public virtual SpecificationsCategory TrademarkNavigation { get; set; }
        public virtual SpecificationsCategory UnitProductNavigation { get; set; }
        public virtual ICollection<DescriptionProduct> DescriptionProducts { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProducts { get; set; }
        public virtual ICollection<HighlightProduct> HighlightProducts { get; set; }
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
    }
}
