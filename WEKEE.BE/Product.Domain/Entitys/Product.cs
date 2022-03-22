using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class Product
    {
        public Product()
        {
            ImageProducts = new HashSet<ImageProduct>();
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Fragile { get; set; }
        public string Origin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public string Gtin { get; set; }
        public string RequiredProductIds { get; set; }
        public string AllowedQuantities { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public int ApprovedRatingSum { get; set; }
        public int NotApprovedRatingSum { get; set; }
        public bool SubjectToAcl { get; set; }
        public bool LimitedToStores { get; set; }
        public bool IsGiftCard { get; set; }
        public int GiftCardTypeId { get; set; }
        public decimal? OverriddenGiftCardAmount { get; set; }
        public bool RequireOtherProducts { get; set; }
        public bool AutomaticallyAddRequiredProducts { get; set; }
        public bool HasUserAgreement { get; set; }
        public string UserAgreementText { get; set; }
        public bool IsRecurring { get; set; }
        public int RecurringCycleLength { get; set; }
        public int RecurringCyclePeriodId { get; set; }
        public int RecurringTotalCycles { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShipSeparately { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
        public int DeliveryDateId { get; set; }
        public int ProductAvailabilityRangeId { get; set; }
        public bool UseMultipleWarehouses { get; set; }
        public bool DisplayStockAvailability { get; set; }
        public bool DisplayStockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public int LowStockActivityId { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public int BackorderModeId { get; set; }
        public bool AllowBackInStockSubscriptions { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
        public bool NotReturnable { get; set; }
        public bool ViewReceived { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }
        public bool AvailableForPreOrder { get; set; }
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        public bool MarkAsNew { get; set; }
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }
        public bool HasTierPrices { get; set; }
        public bool HasDiscountsApplied { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int DisplayOrder { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int? Supplier { get; set; }
        public string ProductAlbum { get; set; }
        public int? Seo { get; set; }

        public virtual Seo SeoNavigation { get; set; }
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
        public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
    }
}
