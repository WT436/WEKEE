using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class ImageProductCardDtos
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Folder { get; set; }
        public int? ImageRoot { get; set; }
        public int? Product { get; set; }
    }
}
