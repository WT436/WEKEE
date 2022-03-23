using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class Seo
    {
        public Seo()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaRobots { get; set; }
        public string MetaRevisitAfter { get; set; }
        public string MetaContentLanguage { get; set; }
        public string MetaContentType { get; set; }
        public string MetaProperty { get; set; }
        public bool IsEnabled { get; set; }
        public int IsLevel { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int? UseAccount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
