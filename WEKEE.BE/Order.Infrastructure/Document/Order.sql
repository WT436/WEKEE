CREATE DATABASE [OrderDB]
GO
USE [OrderDB]
GO

CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CustomOrderNumber] [nvarchar](max) NOT NULL,
	[BillingAddressId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PickupAddressId] [int] NULL,
	[ShippingAddressId] [int] NULL,
	[OrderGuid] [uniqueidentifier] NOT NULL,
	[StoreId] [int] NOT NULL,
	[PickupInStore] [bit] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[ShippingStatusId] [int] NOT NULL,
	[PaymentStatusId] [int] NOT NULL,
	[PaymentMethodSystemName] [nvarchar](max) NULL,
	[CustomerCurrencyCode] [nvarchar](max) NULL,
	[CurrencyRate] [decimal](18, 4) NOT NULL,
	[CustomerTaxDisplayTypeId] [int] NOT NULL,
	[VatNumber] [nvarchar](max) NULL,
	[OrderSubtotalInclTax] [decimal](18, 4) NOT NULL,
	[OrderSubtotalExclTax] [decimal](18, 4) NOT NULL,
	[OrderSubTotalDiscountInclTax] [decimal](18, 4) NOT NULL,
	[OrderSubTotalDiscountExclTax] [decimal](18, 4) NOT NULL,
	[OrderShippingInclTax] [decimal](18, 4) NOT NULL,
	[OrderShippingExclTax] [decimal](18, 4) NOT NULL,
	[PaymentMethodAdditionalFeeInclTax] [decimal](18, 4) NOT NULL,
	[PaymentMethodAdditionalFeeExclTax] [decimal](18, 4) NOT NULL,
	[TaxRates] [nvarchar](max) NULL,
	[OrderTax] [decimal](18, 4) NOT NULL,
	[OrderDiscount] [decimal](18, 4) NOT NULL,
	[OrderTotal] [decimal](18, 4) NOT NULL,
	[RefundedAmount] [decimal](18, 4) NOT NULL,
	[RewardPointsHistoryEntryId] [int] NULL,
	[CheckoutAttributeDescription] [nvarchar](max) NULL,
	[CheckoutAttributesXml] [nvarchar](max) NULL,
	[CustomerLanguageId] [int] NOT NULL,
	[AffiliateId] [int] NOT NULL,
	[CustomerIp] [nvarchar](max) NULL,
	[AllowStoringCreditCardNumber] [bit] NOT NULL,
	[CardType] [nvarchar](max) NULL,
	[CardName] [nvarchar](max) NULL,
	[CardNumber] [nvarchar](max) NULL,
	[MaskedCreditCardNumber] [nvarchar](max) NULL,
	[CardCvv2] [nvarchar](max) NULL,
	[CardExpirationMonth] [nvarchar](max) NULL,
	[CardExpirationYear] [nvarchar](max) NULL,
	[AuthorizationTransactionId] [nvarchar](max) NULL,
	[AuthorizationTransactionCode] [nvarchar](max) NULL,
	[AuthorizationTransactionResult] [nvarchar](max) NULL,
	[CaptureTransactionId] [nvarchar](max) NULL,
	[CaptureTransactionResult] [nvarchar](max) NULL,
	[SubscriptionTransactionId] [nvarchar](max) NULL,
	[PaidDateUtc] [datetime2](7) NULL,
	[ShippingMethod] [nvarchar](max) NULL,
	[ShippingRateComputationMethodSystemName] [nvarchar](max) NULL,
	[CustomValuesXml] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[RedeemedRewardPointsEntryId] [int] NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderItemGuid] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPriceInclTax] [decimal](18, 4) NOT NULL,
	[UnitPriceExclTax] [decimal](18, 4) NOT NULL,
	[PriceInclTax] [decimal](18, 4) NOT NULL,
	[PriceExclTax] [decimal](18, 4) NOT NULL,
	[DiscountAmountInclTax] [decimal](18, 4) NOT NULL,
	[DiscountAmountExclTax] [decimal](18, 4) NOT NULL,
	[OriginalProductCost] [decimal](18, 4) NOT NULL,
	[AttributeDescription] [nvarchar](max) NULL,
	[AttributesXml] [nvarchar](max) NULL,
	[DownloadCount] [int] NOT NULL,
	[IsDownloadActivated] [bit] NOT NULL,
	[LicenseDownloadId] [int] NULL,
	[ItemWeight] [decimal](18, 4) NULL,
	[RentalStartDateUtc] [datetime2](7) NULL,
	[RentalEndDateUtc] [datetime2](7) NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
CREATE TABLE [dbo].[OrderNote](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Note] [nvarchar](max) NOT NULL,
	[OrderId] [int] NOT NULL,
	[DownloadId] [int] NOT NULL,
	[DisplayToCustomer] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
CREATE TABLE [dbo].[RewardPointsHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CustomerId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[PointsBalance] [int] NULL,
	[UsedAmount] [decimal](18, 4) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[EndDateUtc] [datetime2](7) NULL,
	[ValidPoints] [int] NULL,
	[UsedWithOrder] [uniqueidentifier] NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[ShipmentItem](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ShipmentId] [int] NOT NULL,
	[OrderItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[Shipment](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OrderId] [int] NOT NULL,
	[TrackingNumber] [nvarchar](max) NULL,
	[TotalWeight] [decimal](18, 4) NULL,
	[ShippedDateUtc] [datetime2](7) NULL,
	[DeliveryDateUtc] [datetime2](7) NULL,
	[ReadyForPickupDateUtc] [datetime2](7) NULL,
	[AdminComment] [nvarchar](max) NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[RecurringPaymentHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[RecurringPaymentId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[RecurringPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[InitialOrderId] [int] NOT NULL,
	[CycleLength] [int] NOT NULL,
	[CyclePeriodId] [int] NOT NULL,
	[TotalCycles] [int] NOT NULL,
	[StartDateUtc] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastPaymentFailed] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)


CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](200) NOT NULL,
	[CouponCode] [nvarchar](100) NULL,
	[AdminComment] [nvarchar](max) NULL,
	[DiscountTypeId] [int] NOT NULL,
	[UsePercentage] [bit] NOT NULL,
	[DiscountPercentage] [decimal](18, 4) NOT NULL,
	[DiscountAmount] [decimal](18, 4) NOT NULL,
	[MaximumDiscountAmount] [decimal](18, 4) NULL,
	[StartDateUtc] [datetime2](7) NULL,
	[EndDateUtc] [datetime2](7) NULL,
	[RequiresCouponCode] [bit] NOT NULL,
	[IsCumulative] [bit] NOT NULL,
	[DiscountLimitationId] [int] NOT NULL,
	[LimitationTimes] [int] NOT NULL,
	[MaximumDiscountedQuantity] [int] NULL,
	[AppliedToSubCategories] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

CREATE TABLE [dbo].[DiscountRequirement](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DiscountId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[DiscountRequirementRuleSystemName] [nvarchar](max) NULL,
	[InteractionTypeId] [int] NULL,
	[IsGroup] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[DiscountUsageHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DiscountId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[Discount_AppliedToProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Discount_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](400) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[PageSizeOptions] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[ManufacturerTemplateId] [int] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[PictureId] [int] NOT NULL,
	[PageSize] [int] NOT NULL,
	[AllowCustomersToSelectPageSize] [bit] NOT NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[PriceRangeFiltering] [bit] NOT NULL,
	[PriceFrom] [decimal](18, 4) NOT NULL,
	[PriceTo] [decimal](18, 4) NOT NULL,
	[ManuallyPriceRange] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
CREATE TABLE [dbo].[Product_Manufacturer_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ManufacturerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[IsFeaturedProduct] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

CREATE TABLE [dbo].[Discount_AppliedToManufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Discount_Id] [int] NOT NULL,
	[Manufacturer_Id] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

CREATE TABLE [dbo].[Discount_AppliedToCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Discount_Id] [int] NOT NULL,
	[Category_Id] [int] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

CREATE TABLE [dbo].[GiftCard](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PurchasedWithOrderItemId] [int] NULL,
	[GiftCardTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[IsGiftCardActivated] [bit] NOT NULL,
	[GiftCardCouponCode] [nvarchar](max) NULL,
	[RecipientName] [nvarchar](max) NULL,
	[RecipientEmail] [nvarchar](max) NULL,
	[SenderName] [nvarchar](max) NULL,
	[SenderEmail] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[IsRecipientNotified] [bit] NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

CREATE TABLE [dbo].[GiftCardUsageHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[GiftCardId] [int] NOT NULL,
	[UsedWithOrderId] [int] NOT NULL,
	[UsedValue] [decimal](18, 4) NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)