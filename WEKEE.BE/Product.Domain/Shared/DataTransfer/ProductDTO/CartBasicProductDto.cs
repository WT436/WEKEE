using Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductDTO
{
    public class CartBasicProductDto
    {
        public string Name { get; set; }
        public string Trademark { get; set; }
        public string FullDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool HasUserAgreement { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public bool ShipSeparately { get; set; }
        public bool IsFreeShipping { get; set; }
        public int BackorderModeId { get; set; }
        public bool DisableWishlistButton { get; set; }
        public int WishlistNumber { get; set; }
        public bool MarkAsNew { get; set; }
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }
        public List<SpecificationAttributeDto> SpecificationAttributeDtos { get; set; }
    }
}
