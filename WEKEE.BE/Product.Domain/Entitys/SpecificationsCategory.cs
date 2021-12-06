using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class SpecificationsCategory
    {
        public SpecificationsCategory()
        {
            FeatureProductKey1Navigations = new HashSet<FeatureProduct>();
            FeatureProductKey2Navigations = new HashSet<FeatureProduct>();
            HighlightProducts = new HashSet<HighlightProduct>();
            ProductTrademarkNavigations = new HashSet<Product>();
            ProductUnitProductNavigations = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string NameShow { get; set; }
        public int Classify { get; set; }
        public string ClassifyValues { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreate { get; set; }
        public int? CategoryMain { get; set; }

        public virtual CategoryProduct CategoryMainNavigation { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProductKey1Navigations { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProductKey2Navigations { get; set; }
        public virtual ICollection<HighlightProduct> HighlightProducts { get; set; }
        public virtual ICollection<Product> ProductTrademarkNavigations { get; set; }
        public virtual ICollection<Product> ProductUnitProductNavigations { get; set; }
    }
}
