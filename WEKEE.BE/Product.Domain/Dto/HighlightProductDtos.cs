using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class HighlightProductDtos
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string NameShow { get; set; }
        public string Values { get; set; }
        public int DisplayOrder { get; set; }
        public int? Product { get; set; }
    }
}
