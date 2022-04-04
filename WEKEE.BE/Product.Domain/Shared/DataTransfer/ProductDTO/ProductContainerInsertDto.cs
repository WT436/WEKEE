using Product.Domain.Shared.DataTransfer.CategoryProductDTO;
using Product.Domain.Shared.DataTransfer.FeatureProductDTO;
using Product.Domain.Shared.DataTransfer.ProductTagDTO;
using Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductDTO
{
    public class ProductContainerInsertDto
    {
        public ProductInsertDto ProductInsertDto { get; set; }
        public List<int> productTagDtos { get; set; }
        public List<string> ImageRoot { get; set; }
        public List<SpecificationProductInsertDto> SpecificationProductDtos { get; set; }
        public CategoryProductAddProductDto CategoryProduct { get; set; }
        public List<FeatureProductInsertDto> FeatureProductInsertDtos { get; set; }
    }
}
