using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.FeatureProductDTO
{
    public class FeatureProductInsertDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal LengthAdjustment { get; set; }
        public decimal WidthAdjustment { get; set; }
        public decimal HeightAdjustment { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
        public string PictureString { get; set; }
        public bool MainProduct { get; set; }
        public List<ProductAttributeValueInsertDto> ProductAttributeValueInsertDtos { get; set; }
    }
}
