using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ImageProductDTO
{
    public class ImageForProductDto
    {
        public int ImageRoot { get; set; }
        public string VirtualPath { get; set; }
        public string Size { get; set; }
        public bool IsCover { get; set; }
        public string AltAttribute { get; set; }
        public string SeoFilename { get; set; }
        public string TitleAttribute { get; set; }
        public int DisplayOrder { get; set; }
    }
}
