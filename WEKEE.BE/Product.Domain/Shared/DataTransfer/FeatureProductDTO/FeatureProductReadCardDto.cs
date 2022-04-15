using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.FeatureProductDTO
{
    public class FeatureProductReadCardDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
        public int PictureStringId { get; set; }
        public bool MainProduct { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
