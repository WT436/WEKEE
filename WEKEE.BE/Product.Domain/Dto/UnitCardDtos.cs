using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class UnitCardDtos
    {
        public ProductCardDtos productCardDtos { get; set; }
        public List<FeatureProductCardDtos> featureProductCardDtos { get; set; }
        public List<ImageProductCardDtos> imageProductCardDtos { get; set; }
        public List<HighlightProductCardDtos> highlightProductCardDtos { get; set; }
    }
}
