using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ImageProduct
    {
        public ImageProduct()
        {
            CategoryProducts = new HashSet<CategoryProduct>();
            FeatureProductImageSquaresPictures = new HashSet<FeatureProduct>();
            FeatureProductPictures = new HashSet<FeatureProduct>();
            InverseImageRootNavigation = new HashSet<ImageProduct>();
            ProductPictureMappings = new HashSet<ProductPictureMapping>();
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

        public virtual ImageProduct ImageRootNavigation { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProductImageSquaresPictures { get; set; }
        public virtual ICollection<FeatureProduct> FeatureProductPictures { get; set; }
        public virtual ICollection<ImageProduct> InverseImageRootNavigation { get; set; }
        public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
    }
}
