using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class CreateProductDtos
    {
        public ProductDtos ProductDto { get; set; }
        public List<FeatureProductDtos> FeatureProductDtos { get; set; }
        public List<ImageProductDtos> ImageProductDtos { get; set; }
        public List<HighlightProductDtos> HighlightProductDtos { get; set; }
    }
}
