using Product.Domain.Shared.DataTransfer.ImageProductDTO;
using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.FeatureProductDTO
{
    public class FeatureProductContainerDto
    {
        public List<ProductReadForCartDto> ProductReadForCartDto { get; set; }
        public List<AttributeValueReadCartDto> KeyValuesName { get; set; }
        public List<ImageWithValueAttributeDto> RenderImage { get; set; }
    }
}
