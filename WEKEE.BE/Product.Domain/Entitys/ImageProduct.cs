using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class ImageProduct
    {
        public ImageProduct()
        {
            InverseImageRootNavigation = new HashSet<ImageProduct>();
        }

        public int Id { get; set; }
        public bool IsCover { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool IsNew { get; set; }
        public string VirtualPath { get; set; }
        public string Size { get; set; }
        public string Folder { get; set; }
        public int? ImageRoot { get; set; }
        public int? Product { get; set; }

        public virtual ImageProduct ImageRootNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
        public virtual ICollection<ImageProduct> InverseImageRootNavigation { get; set; }
    }
}
