using Product.Domain.Shared.DataTransfer.FeatureProductDTO;
using Product.Domain.Shared.DataTransfer.ImageProductDTO;
using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Domain.CoreDomain
{
    public class FeatureProductDomainCore
    {
        public FeatureProductContainerDto ProcessFeatureKeyAttribute(List<ProductReadForCartDto> input)
        {

            List<AttributeValueReadCartDto> KeyValuesName = new List<AttributeValueReadCartDto>();
            var keyAttribute = input.Select(m => m.Name).Distinct().ToList();

            keyAttribute.ForEach(key =>
            {
                var Values = input.Where(w => w.Name == key).Select(m => m.Values).Distinct().ToList();
                KeyValuesName.Add(new AttributeValueReadCartDto
                {
                    KeyName = key,
                    ValuesName = Values
                });
            });

            List<ImageWithValueAttributeDto> imageWithValueAttributeDtos = new List<ImageWithValueAttributeDto>();

            KeyValuesName.FirstOrDefault().ValuesName.ForEach(e =>
            {
                var data = input.FirstOrDefault(m => m.Values == e).IMGS80x80;
                imageWithValueAttributeDtos.Add(new ImageWithValueAttributeDto { IMGS80x80 = data, ValueName = e });
            });

            FeatureProductContainerDto featureProductContainerDto = new FeatureProductContainerDto
            {
                ProductReadForCartDto = input,
                KeyValuesName = KeyValuesName,
                RenderImage = imageWithValueAttributeDtos
            };

            return featureProductContainerDto;
        }
    }
}
