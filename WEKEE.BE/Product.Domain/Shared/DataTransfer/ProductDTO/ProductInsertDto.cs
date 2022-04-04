using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductDTO
{
    public class ProductInsertDto
    {
        [MaxLength(100,ErrorMessage = MessageOutput.MAX_LENGTH)]
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public string Name { get; set; }
        public bool? Fragile { get; set; }
        [MaxLength(300, ErrorMessage = MessageOutput.MAX_LENGTH)]
        public string Origin { get; set; }
        public int UnitAttributeId { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
       
        // ship hang
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShipSeparately { get; set; }
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public decimal AdditionalShippingCharge { get; set; }
        public int DeliveryDateId { get; set; }
        // phạm vi khả dụng
        public int ProductAvailabilityRangeId { get; set; }
       
        // dùng nhiều kho lưu trữ
        public bool UseMultipleWarehouses { get; set; }
        public bool DisplayStockAvailability { get; set; }
        public bool DisplayStockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public int LowStockActivityId { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        // đặt hàng trước
        public int BackorderModeId { get; set; }
        public bool AllowBackInStockSubscriptions { get; set; }
        // cài đặt đặt hàng
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        // thuộc tính đặt hàng
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
        // không trả lại hàng
        public bool NotReturnable { get; set; }
        public bool ViewReceived { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }
        // cấp độ giá
        public bool HasTierPrices { get; set; }
        public bool HasDiscountsApplied { get; set; }

        public int CreateBy { get; set; }
    }
}
