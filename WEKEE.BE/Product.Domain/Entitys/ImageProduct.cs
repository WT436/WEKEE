using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class ImageProduct
    {
        public ImageProduct()
        {
            FeatureProducts = new HashSet<FeatureProduct>();
            InverseImageRootNavigation = new HashSet<ImageProduct>();
        }

        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Folder { get; set; }
        public int? ImageRoot { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsCover { get; set; }
        public int? Product { get; set; }

        public virtual ImageProduct ImageRootNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProducts { get; set; }
        public virtual ICollection<ImageProduct> InverseImageRootNavigation { get; set; }
    }
}
