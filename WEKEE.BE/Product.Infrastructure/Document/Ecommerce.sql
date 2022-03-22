CREATE DATABASE [ProductDB]
GO
USE [ProductDB]

GO
--==============================================
-- Name        : [CategoryProduct]
-- Description : Lưu danh mục sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [CategoryProduct] (
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
	[nameCategory] NVARCHAR(300) UNIQUE NOT NULL,
	[urlCategory] NVARCHAR(300) UNIQUE NOT NULL,
	[iconCategory] VARCHAR(200) NUll,	
	[levelCategory] INT DEFAULT 1 NOT NULL CHECK([levelCategory]>0 AND [levelCategory]<5),
	[categoryMain] INT NUll,	
	[numberOrder] INT NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
--=========>Connect Table<===========--
)
GO
--==============================================
-- Name        :  [Seo]
-- Description :  Thẻ seo sản phẩm, nhà cung cấp
-- Date Update : 
--==============================================
CREATE TABLE [Seo]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[meta_title] NVARCHAR(70) NULL,				--Thẻ tiêu đề khi hiển thị trên Google nó sẽ hiển thị từ 60 – 70 ký tự nếu vượt quá số ký tự cho phép thì tiêu đề của bạn sẽ bị cắt phần dư đi và thay bằng dấu 3 chấm (…).
	[meta_Description] NVARCHAR(MAX) NULL,		--Meta Description là thẻ mô tả nội dung của một trang web, tóm tắt ngắn gọn nội dung của trang đó để hiển thị trên công cụ tìm kiếm.
	[meta_Keywords] NVARCHAR(MAX) NULL,			--Meta Keywords là thẻ mô tả từ khóa của một trang. 
	[meta_Robots] NVARCHAR(20) NULL,				--Meta Robots có nhiều giá trị nhưng thường thì một trang nên sử dụng 3 giá trị sau đây:
												--noodp: Ngăn cản các công cụ tìm kiếm tạo các mô tả description từ các thư mục danh bạ Web DMOZ như là một phần của snippet trong trang kết quả tìm kiếm.
												--index: Đánh chỉ số trang.
												--follow: Bọ tìm kiếm sẽ đọc các liên kết văn bản trong trang và sau đó sẽ xử lý, truy vấn nó.
												--Cách giá trị cách nhau bằng dấu phẩy (,). Ví dụ: noodp,index,follow.
	[meta_Revisit_After] NVARCHAR(MAX) NULL,		--Meta Revisit After là thẻ khai báo cho bọ tìm kiếm thời gian quay trở lại trang web của bạn.
	[meta_Content_Language] NVARCHAR(MAX) NULL,	--Meta Content Language là thẻ khai bao ngôn ngữ website của bạn, giúp các công cụ tìm kiếm hướng đối tượng người dùng cho website có sử dụng thẻ này.
	[meta_Content_Type] NVARCHAR(MAX) NULL,		--Meta Content Type là thẻ khai báo mã hiển thị ngôn ngữ của website chứa nó.
	[meta_Property] NVARCHAR(MAX) NULL,			--là thẻ khai báo cấu trúc của một trang web
	[isEnabled] BIT DEFAULT 0  not null,			-- kiểm tra xem đã xóa hay chưa
	[isLevel] INT DEFAULT 0 not null	,			-- cấp độ của của seo 	
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
--=========>Connect Table<===========--
	[use_account] INT,
)
GO
--==============================================
-- Name        : [Product]
-- Description : Lưu sản phẩm thông tin, các trường check, các trường hiển thị.....
-- Date Update : 
--==============================================
CREATE TABLE [Product]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[name] NVARCHAR(100) NOT NULL,--*
	[fragile] BIT DEFAULT 0 , -- Hàng Dễ Vỡ 
	[origin] NVARCHAR(300), -- Nguồn Gốc *
	
	[Sku] [nvarchar](400) NULL, -- giúp cho việc phân loại hàng hóa, quản lý kho
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[Gtin] [nvarchar](400) NULL,		
	[RequiredProductIds] [nvarchar](1000) NULL,	
	[AllowedQuantities] [nvarchar](1000) NULL, -- số lượng tối đa
	[ShortDescription] [nvarchar](max) NULL, -- mô tả
	[FullDescription] [nvarchar](max) NULL, -- mô tả chi tiết	
	[ShowOnHomepage] [bit] NOT NULL, -- hiển thị trên trang chính	
	[AllowCustomerReviews] [bit] NOT NULL, -- cho phép khách hàng đánh giá	
	[ApprovedRatingSum] [int] NOT NULL, -- xếp hạng trên các sản phẩm cùng loại tốt, tính toán theo ngày/lần
	[NotApprovedRatingSum] [int] NOT NULL, -- xếp hạng trên các sản phẩm cùng loại xấu, tính toán theo ngày/lần	
	[SubjectToAcl] [bit] NOT NULL, -- kiểm soát truy cập
	[LimitedToStores] [bit] NOT NULL, -- giới hạn cho của hàng
	
	[IsGiftCard] [bit] NOT NULL, -- có thẻ tặng quà không
	[GiftCardTypeId] [int] NOT NULL, -- mã nhóm thẻ tặng quà
	[OverriddenGiftCardAmount] [decimal](18, 4) NULL, -- số lượng thẻ tặng quà bị ghi đè
	
	[RequireOtherProducts] [bit] NOT NULL, -- yêu cầu thêm sản phẩm khác
	[AutomaticallyAddRequiredProducts] [bit] NOT NULL, -- tự động thêm sản phẩm bắt buộc	
	
	[HasUserAgreement] [bit] NOT NULL, -- thỏa thuận người dùng (Trả góp)
	[UserAgreementText] [nvarchar](max) NULL, -- chi tiết thỏa thuận
	[IsRecurring] [bit] NOT NULL, -- định kỳ trả góp
	[RecurringCycleLength] [int] NOT NULL,-- thời hạn trả góp
	[RecurringCyclePeriodId] [int] NOT NULL, -- id chu kỳ trả góp
	[RecurringTotalCycles] [int] NOT NULL, -- tổng thời gian trả góp	
	
	[IsShipEnabled] [bit] NOT NULL, -- trạng thái giao hàng
	[IsFreeShipping] [bit] NOT NULL, -- giao hàng free
	[ShipSeparately] [bit] NOT NULL, -- giao riêng
	[AdditionalShippingCharge] [decimal](18, 4) NOT NULL, -- phí vận chuyển bổ xung
	[DeliveryDateId] [int] NOT NULL, -- id ngày giao hàng
	
	[ProductAvailabilityRangeId] [int] NOT NULL, -- phạm vi khả dụng (địa bàn)
	
	[UseMultipleWarehouses] [bit] NOT NULL, -- sử dụng nhiều kho lưu trữ

	[DisplayStockAvailability] [bit] NOT NULL, -- hiện thị tình trạng kho
	[DisplayStockQuantity] [bit] NOT NULL, -- hiện thị số lượng kho hàng
	[MinStockQuantity] [int] NOT NULL, -- hàng tồn kho tối thiểu
	[LowStockActivityId] [int] NOT NULL, -- id hàng còn thấp ??
	[NotifyAdminForQuantityBelow] [int] NOT NULL, -- thông báo cho admin về số lượng còn thấp
	
	[BackorderModeId] [int] NOT NULL, -- chế độ đặt hàng trước
	[AllowBackInStockSubscriptions] [bit] NOT NULL, -- cho phép quay về kho
	
	[OrderMinimumQuantity] [int] NOT NULL, -- số lượng đặt hàng tối thiểu
	[OrderMaximumQuantity] [int] NOT NULL, -- số lượng đặt hàng tối đa
	[AllowAddingOnlyExistingAttributeCombinations] [bit] NOT NULL, -- có nhiều thuộc tính
	[NotReturnable] [bit] NOT NULL, -- Không thể trả lại hàng
	[ViewReceived] [bit] NOT NULL, -- Xem Hàng khi nhận
	[DisableBuyButton] [bit] NOT NULL, -- tắt đặt hàng
	[DisableWishlistButton] [bit] NOT NULL, -- tắt yêu thích
	[AvailableForPreOrder] [bit] NOT NULL, -- đặt hàng trước
	[PreOrderAvailabilityStartDateTimeUtc] [datetime2](7) NULL, -- thời gian có hàng cho đặt trước	
	
	[MarkAsNew] [bit] NOT NULL, -- đánh giấu là sản phẩm mới
	[MarkAsNewStartDateTimeUtc] [datetime2](7) NULL, -- đánh giấu là ngày bắt đầu sản phẩm mới
	[MarkAsNewEndDateTimeUtc] [datetime2](7) NULL, -- đánh giấu kết thúc sản phẩm mới
	
	[HasTierPrices] [bit] NOT NULL, -- cấp độ giá
	[HasDiscountsApplied] [bit] NOT NULL, -- áp dụng giảm giá
	
	[Weight] [decimal](18, 4) NOT NULL, -- trọng lượng
	[Length] [decimal](18, 4) NOT NULL, -- chiều rộng
	[Width] [decimal](18, 4) NOT NULL, -- chiều ngang
	[Height] [decimal](18, 4) NOT NULL, -- chiều cao
	
	[DisplayOrder] [int] NOT NULL, -- hiển thị sản phẩm
	[Published] [bit] NOT NULL, -- được phát hành
	[Deleted] [bit] NOT NULL, -- đã xóa
	[CreatedOnUtc] [datetime2](7) NOT NULL, --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL, -- ngày update

--=========>Connect Table<===========--
	[supplier] INT , -- nhà cung cấp --*
	[productAlbum] NVARCHAR(200) NOT NULL DEFAULT('highlights'),-- album sản phẩm --*
	[seo] INT FOREIGN KEY REFERENCES Seo (id),-- seo --*
)
GO
--==============================================
-- Name        : [Product_Category_Mapping]
-- Description : Nhóm Danh mục sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [Product_Category_Mapping]( -- kết nối nhiều category lại với sản phẩm
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryId] [int] NOT NULL FOREIGN KEY REFERENCES [CategoryProduct] ([Id]), -- id chủng loại
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product] ([Id]), -- id sản phẩm 
	[IsFeaturedProduct] [bit] NOT NULL, -- sản phẩm nổi bật
	[DisplayOrder] [int] NOT NULL, -- vị trí hiển thị
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
--==============================================
-- Name        : [ImageProduct]
-- Description : Lưu ảnh sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [ImageProduct]
(
--=========>Trường Dữ Liệu<===========--
	[Id] INT IDENTITY(1,1) NOT NULL primary key,
	[IsCover] BIT NOT NULL DEFAULT (0),
	[MimeType] [nvarchar](40) NOT NULL,
	[SeoFilename] [nvarchar](300) NULL,
	[AltAttribute] [nvarchar](max) NULL,
	[TitleAttribute] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
	[VirtualPath] [nvarchar](max) NULL,
	[Size] VARCHAR(20) NOT NULL,
	[Folder] VARCHAR(50) NOT NULL,
	[ImageRoot] INT FOREIGN KEY REFERENCES [ImageProduct] (id),
--=========>Connect Table<===========--
	[Product] INT NULL FOREIGN KEY REFERENCES [Product] (id)
)
GO
--==============================================
-- Name        : [Product_Picture_Mapping]
-- Description : Một sản phẩm thì có nhiều ảnh
-- Date Update : 
--==============================================
CREATE TABLE [Product_Picture_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureId] [int] NOT NULL FOREIGN KEY REFERENCES [ImageProduct] (Id),
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product] (Id),
	[DisplayOrder] [int] NOT NULL,
	[isDelete] [bit] NOT NULL DEFAULT(0),
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
--==============================================
-- Name        : [ProductTag]
-- Description : Thẻ sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [ProductTag](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](400) NOT NULL,
	[isDelete] [bit] NOT NULL DEFAULT(0),
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        : [Product_ProductTag_Mapping]
-- Description : Kết nối sản phẩm và tag
-- Date Update : 
--==============================================
CREATE TABLE [Product_ProductTag_Mapping](
	[Product_Id] [int] NOT NULL FOREIGN KEY REFERENCES [Product] (Id),
	[ProductTag_Id] [int] NOT NULL FOREIGN KEY REFERENCES [ProductTag] (Id),
)

GO
--==============================================
-- Name        : [ProductAttribute]
-- Description : Thuộc tính sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [ProductAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL DEFAULT(0),
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        : [PredefinedProductAttributeValue]
-- Description : Giá trị thuộc tính sản phẩm mặc định
-- Date Update : 
--==============================================
CREATE TABLE [PredefinedProductAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ProductAttributeId] [int] NOT NULL FOREIGN KEY REFERENCES [ProductAttribute](Id),
	[PriceAdjustment] [decimal](18, 4) NOT NULL,
	[PriceAdjustmentUsePercentage] [bit] NOT NULL,
	[WeightAdjustment] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL
)

GO
--==============================================
-- Name        :  
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [ProductAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](400) NOT NULL,
	[ColorSquaresRgb] [nvarchar](100) NULL,
	[ProductAttributeMappingId] [int] NOT NULL,
	[AttributeValueTypeId] [int] NOT NULL,
	[AssociatedProductId] [int] NOT NULL,
	[ImageSquaresPictureId] [int] NOT NULL,
	[PriceAdjustment] [decimal](18, 4) NOT NULL,
	[PriceAdjustmentUsePercentage] [bit] NOT NULL,
	[WeightAdjustment] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[CustomerEntersQty] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[PictureId] [int] NOT NULL
)

GO
--==============================================
-- Name        :  [Product_ProductAttribute_Mapping]
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [Product_ProductAttribute_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductAttributeId] [int] NOT NULL FOREIGN KEY REFERENCES [ProductAttribute](Id),
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product](Id),
	[TextPrompt] [nvarchar](max) NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL FOREIGN KEY REFERENCES [ProductAttributeValue](Id),
	[DisplayOrder] [int] NOT NULL,
	[ValidationMinLength] [int] NULL,
	[ValidationMaxLength] [int] NULL,
	[ValidationFileAllowedExtensions] [nvarchar](max) NULL,
	[ValidationFileMaximumSize] [int] NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ConditionAttributeXml] [nvarchar](max) NULL
)
GO
--==============================================
-- Name        : [Warehouse]
-- Description : Kho
-- Date Update : 
--==============================================
CREATE TABLE [Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](400) NOT NULL,
	[AdminComment] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL
)
GO
--==============================================
-- Name        : [ProductWarehouseInventory]
-- Description : Kiểm kê kho hàng
-- Date Update : 
--==============================================
CREATE TABLE [ProductWarehouseInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[ReservedQuantity] [int] NOT NULL
)
GO
--==============================================
-- Name        :  [StockQuantityHistory]
-- Description : Lịch sử giao dịch kho
-- Date Update : 
--==============================================
CREATE TABLE [StockQuantityHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] [int] NOT NULL,
	[QuantityAdjustment] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[CombinationId] [int] NULL,
	[WarehouseId] [int] NULL
)
GO
--==============================================
-- Name        : [SpecificationAttributeGroup]
-- Description : Thuộc tính đặc điểm kỹ thuật sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [SpecificationAttributeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NOT NULL
)
GO
--==============================================
-- Name        : [SpecificationAttribute]
-- Description : Thuộc tính đặc điểm kỹ thuật
-- Date Update : 
--==============================================
CREATE TABLE [SpecificationAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[SpecificationAttributeGroupId] [int] NULL FOREIGN KEY REFERENCES [SpecificationAttributeGroup](Id),
	[DisplayOrder] [int] NOT NULL
)
GO
--==============================================
-- Name        : [SpecificationAttributeOption]
-- Description : Tùy chọn đặc điểm kỹ thuật
-- Date Update : 
--==============================================
CREATE TABLE [SpecificationAttributeOption](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[ColorSquaresRgb] [nvarchar](100) NULL,
	[SpecificationAttributeId] [int] NOT NULL FOREIGN KEY REFERENCES [SpecificationAttribute](Id),
	[DisplayOrder] [int] NOT NULL
)
GO
--==============================================
-- Name        : [Product_SpecificationAttribute_Mapping]
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [Product_SpecificationAttribute_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomValue] [nvarchar](4000) NULL,
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product](Id),
	[SpecificationAttributeOptionId] [int] NOT NULL FOREIGN KEY REFERENCES [SpecificationAttributeOption](Id),
	[AttributeTypeId] [int] NOT NULL,
	[AllowFiltering] [bit] NOT NULL,
	[ShowOnProductPage] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL
)
--==============================================
-- Name        : 
-- Description : 
-- Date Update : 
--==============================================

