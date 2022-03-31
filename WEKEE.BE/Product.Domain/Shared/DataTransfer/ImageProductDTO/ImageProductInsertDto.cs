using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ImageProductDTO
{
    public class ImageProductInsertDto
    {
        public bool IsCover { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool IsNew { get; set; }
        public string VirtualPath { get; set; }
        public string Size { get; set; }
        public string Folder { get; set; }
    }
}
