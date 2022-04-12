CREATE DATABASE [ProductDB]
GO
USE [ProductDB]
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
	[IsNew] [bit] NOT NULL  DEFAULT (0),
	[VirtualPath] [nvarchar](max) NULL,
	[Size] VARCHAR(20) NOT NULL,
	[Folder] VARCHAR(50) NOT NULL,
	[ImageRoot] INT NULL FOREIGN KEY REFERENCES [ImageProduct] (id)
)
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
	[iconCategory] INT FOREIGN KEY REFERENCES [ImageProduct] (Id),	
	[levelCategory] INT DEFAULT 1 NOT NULL CHECK([levelCategory]>0 AND [levelCategory]<5),
	[categoryMain] INT NUll FOREIGN KEY REFERENCES [CategoryProduct] (Id),	
	[numberOrder] INT NOT NULL CHECK([numberOrder] > 0),
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
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
	[createdOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[updatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
--=========>Connect Table<===========--
	[use_account] INT,
)
GO

--==============================================
-- Name        : [ProductAttribute]
-- Description : Lưu các Thuộc tính sản phẩm, name key, unit .... Chính cho từng loại category
--				 Vd : một category có rất nhiều đơn vị tính như lô, cái... Về thuộc tính thì cũng có những sản phẩm được nhận diện qua màu sắc,
--					  kích thước hay điện thoại cũng có loại theo bộ nhớ, theo màn hinhfhay đơn giản chỉ là màu sắc.
-- Date Update : 
--==============================================
CREATE TABLE [ProductAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL, -- khóa
	[Types] INT DEFAULT(0) NOT NULL CHECK([Types]>=0 AND [Types]<=5),
	[CategoryProductId] [int] NULL FOREIGN KEY REFERENCES [CategoryProduct](Id), -- category
	[isDelete] BIT NOT NULL DEFAULT(0), -- đã xóa 
	[CreateBy] INT NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
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
	[name] NVARCHAR(200) NOT NULL,--*
	[fragile] BIT DEFAULT(0) , -- Hàng Dễ Vỡ 
	[origin] NVARCHAR(300), -- Nguồn Gốc *
	[Trademark] INT NOT NULL FOREIGN KEY REFERENCES [ProductAttribute] (Id), -- thương hiệu
	[UnitProduct] INT NOT NULL FOREIGN KEY REFERENCES [ProductAttribute] (Id), -- đơn vị tính

	[Sku] [nvarchar](400) NULL, -- giúp cho việc phân loại hàng hóa, quản lý kho
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[Gtin] [nvarchar](400) NULL,

	[ShortDescription] [nvarchar](max) NULL, -- mô tả
	[FullDescription] [nvarchar](max) NULL, -- mô tả chi tiết	
	[ShowOnHomepage] [bit] NOT NULL DEFAULT(0), -- hiển thị trên trang chính	
	[AllowCustomerReviews] [bit] NOT NULL DEFAULT(0), -- cho phép khách hàng đánh giá	
	[ApprovedRatingSum] [int] NOT NULL DEFAULT(0), -- xếp hạng trên các sản phẩm cùng loại tốt, tính toán theo ngày/lần
	[NotApprovedRatingSum] [int] NOT NULL DEFAULT(0), -- xếp hạng trên các sản phẩm cùng loại xấu, tính toán theo ngày/lần	
	[SubjectToAcl] [bit] NOT NULL DEFAULT(0), -- kiểm soát truy cập
	[LimitedToStores] [bit] NOT NULL DEFAULT(0), -- giới hạn cho của hàng
	
	[IsGiftCard] [bit] NOT NULL DEFAULT(0), -- có thẻ tặng quà không
	[GiftCardTypeId] [int] NOT NULL DEFAULT(0), -- mã nhóm thẻ tặng quà
	[OverriddenGiftCardAmount] [decimal](18, 4) NULL, -- số lượng thẻ tặng quà bị ghi đè
	
	[RequireOtherProducts] [bit] NOT NULL DEFAULT(0), -- yêu cầu thêm sản phẩm khác
	[AutomaticallyAddRequiredProducts] [bit] NOT NULL DEFAULT(0), -- tự động thêm sản phẩm bắt buộc	
	
	[HasUserAgreement] [bit] NOT NULL DEFAULT(0), -- thỏa thuận người dùng (Trả góp)
	[UserAgreementText] [nvarchar](max) NULL, -- chi tiết thỏa thuận
	[IsRecurring] [bit] NOT NULL DEFAULT(0), -- định kỳ trả góp
	[RecurringCycleLength] [int] NOT NULL DEFAULT(0),-- thời hạn trả góp
	[RecurringCyclePeriodId] [int] NOT NULL DEFAULT(0), -- id chu kỳ trả góp
	[RecurringTotalCycles] [int] NOT NULL DEFAULT(0), -- tổng thời gian trả góp	
	
	[IsShipEnabled] [bit] NOT NULL DEFAULT(0), -- trạng thái giao hàng
	[IsFreeShipping] [bit] NOT NULL DEFAULT(0), -- giao hàng free
	[ShipSeparately] [bit] NOT NULL DEFAULT(0), -- giao riêng
	[AdditionalShippingCharge] [decimal](18, 4) NOT NULL DEFAULT(0), -- phí vận chuyển bổ xung
	[DeliveryDateId] [int] NOT NULL DEFAULT(0), -- id ngày giao hàng
	
	[ProductAvailabilityRangeId] [int] NOT NULL DEFAULT(0), -- phạm vi khả dụng (địa bàn)
	
	[UseMultipleWarehouses] [bit] NOT NULL DEFAULT(0), -- sử dụng nhiều kho lưu trữ

	[DisplayStockAvailability] [bit] NOT NULL DEFAULT(0), -- hiện thị tình trạng kho
	[DisplayStockQuantity] [bit] NOT NULL DEFAULT(0), -- hiện thị số lượng kho hàng
	[MinStockQuantity] [int] NOT NULL DEFAULT(0), -- hàng tồn kho tối thiểu
	[LowStockActivityId] [int] NOT NULL DEFAULT(0), -- id hàng còn thấp ??
	[NotifyAdminForQuantityBelow] [int] NOT NULL DEFAULT(0), -- thông báo cho admin về số lượng còn thấp
	
	[BackorderModeId] [int] NOT NULL DEFAULT(0), -- chế độ đặt hàng trước
	[AllowBackInStockSubscriptions] [bit] NOT NULL DEFAULT(0), -- cho phép quay về kho
	
	[OrderMinimumQuantity] [int] NOT NULL DEFAULT(0), -- số lượng đặt hàng tối thiểu
	[OrderMaximumQuantity] [int] NOT NULL DEFAULT(0), -- số lượng đặt hàng tối đa
	[AllowAddingOnlyExistingAttributeCombinations] [bit] NOT NULL DEFAULT(0), -- có nhiều thuộc tính
	
	[NotReturnable] [bit] NOT NULL DEFAULT(0), -- Không thể trả lại hàng
	[ViewReceived] [bit] NOT NULL DEFAULT(0), -- Xem Hàng khi nhận
	[DisableBuyButton] [bit] NOT NULL DEFAULT(0), -- tắt đặt hàng
	[DisableWishlistButton] [bit] NOT NULL DEFAULT(0), -- tắt yêu thích
	[WishlistNumber] [int] NOT NULL DEFAULT(0), -- tắt yêu thích
	[AvailableForPreOrder] [bit] NOT NULL DEFAULT(0), -- đặt hàng trước
	[PreOrderAvailabilityStartDateTimeUtc] DATETIME2(7) NULL DEFAULT(GETDATE()), -- thời gian có hàng cho đặt trước	
	
	[MarkAsNew] [bit] NOT NULL DEFAULT(0), -- đánh giấu là sản phẩm mới
	[MarkAsNewStartDateTimeUtc] DATETIME2(7) NULL DEFAULT(GETDATE()), -- đánh giấu là ngày bắt đầu sản phẩm mới
	[MarkAsNewEndDateTimeUtc] DATETIME2(7) NULL DEFAULT(GETDATE()), -- đánh giấu kết thúc sản phẩm mới
	
	[HasTierPrices] [bit] NOT NULL DEFAULT(0), -- cấp độ giá
	[HasDiscountsApplied] [bit] NOT NULL DEFAULT(0), -- áp dụng giảm giá	

	[Published] [bit] NOT NULL DEFAULT(0), -- được phát hành
	[Deleted] [bit] NOT NULL DEFAULT(0), -- đã xóa
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update

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
	[IsFeaturedProduct] [bit] NOT NULL DEFAULT (0), -- sản phẩm nổi bật
	[DisplayOrder] [int] NOT NULL, -- vị trí hiển thị
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
--==============================================
-- Name        : [Product_Picture_Mapping]
-- Description : Một sản phẩm thì có nhiều ảnh
-- Date Update : 
--==============================================
CREATE TABLE [Product_Picture_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PictureId] [int] NOT NULL FOREIGN KEY REFERENCES [ImageProduct] (Id),
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product] (Id),
	[DisplayOrder] [int] NOT NULL,
	[isDelete] [bit] NOT NULL DEFAULT(0),
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
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
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        : [Product_ProductTag_Mapping]
-- Description : Kết nối sản phẩm và tag
-- Date Update : 
--==============================================
CREATE TABLE [Product_ProductTag_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Product_Id] [int] NOT NULL FOREIGN KEY REFERENCES [Product] (Id),
	[ProductTag_Id] [int] NOT NULL FOREIGN KEY REFERENCES [ProductTag] (Id),
	[CreateBy] [int] NOT NULL,
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        : [ProductAttributeValue]
-- Description : Thuộc tính sản phẩm
-- Date Update : 
--==============================================
CREATE TABLE [ProductAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Key] INT NOT NULL  FOREIGN KEY REFERENCES [ProductAttribute](Id), -- khóa
	[Values] [nvarchar](max) NULL, -- giá trị
	[isDelete] [bit] NOT NULL DEFAULT(0), -- đã xóa 
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        :  [FeatureProduct]
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [FeatureProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product](Id), -- sản phẩm chính
	
	[WeightAdjustment] [decimal](18, 4) NOT NULL DEFAULT(0), -- trọng lượng
	[LengthAdjustment] [decimal](18, 4) NOT NULL DEFAULT(0), -- chiều rộng
	[WidthAdjustment] [decimal](18, 4) NOT NULL DEFAULT(0), -- chiều ngang
	[HeightAdjustment] [decimal](18, 4) NOT NULL DEFAULT(0), -- chiều cao	
	[Price] [decimal](18, 4) NOT NULL,

	[Quantity] [int] NOT NULL, -- số lượng
	[DisplayOrder] [int] NOT NULL,-- vị trí hiển thị
	[PictureId] [int] NOT NULL  FOREIGN KEY REFERENCES [ImageProduct](Id), -- id ảnh
	[MainProduct] [bit] DEFAULT(0) NOT NULL,
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
--==============================================
-- Name        : [ProductAttributeMapping]
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [ProductAttributeMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FeatureProductId] [int] NOT NULL FOREIGN KEY REFERENCES [FeatureProduct](Id),
	[ProductAttributeValuesId] [int] NOT NULL FOREIGN KEY REFERENCES [ProductAttributeValue](Id),
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
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
-- Name        : [StockQuantityHistory]
-- Description : Lịch sử giao dịch kho
-- Date Update : 
--==============================================
CREATE TABLE [StockQuantityHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] [int] NOT NULL,
	[QuantityAdjustment] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedOnUtc] DATETIME2(7) NOT NULL,
	[CombinationId] [int] NULL,
	[WarehouseId] [int] NULL
)
GO
--==============================================
-- Name        : [SpecificationAttribute]
-- Description : Tùy chọn đặc điểm kỹ thuật - 
-- Date Update : 
--==============================================
CREATE TABLE [SpecificationAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[key] NVARCHAR(200) NOT NULL,--key
	[CategoryProductId] [int] NOT NULL FOREIGN KEY REFERENCES [CategoryProduct](Id), -- category
	[GroupSpecification] NVARCHAR(200) NULL,-- nhóm
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
--==============================================
-- Name        : [Product_SpecificationAttribute_Mapping]
-- Description : 
-- Date Update : 
--==============================================
CREATE TABLE [Product_SpecificationAttribute_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CustomValue] [nvarchar](4000) NULL, -- giá trị
	[ProductId] [int] NOT NULL FOREIGN KEY REFERENCES [Product](Id), -- tên sản phẩm
	[SpecificationId] [int] NOT NULL FOREIGN KEY REFERENCES [SpecificationAttribute](Id),-- mã key
	[AttributeTypeId] [int] NULL FOREIGN KEY REFERENCES [ProductAttribute] (Id),
	[AllowFiltering] [bit] NOT NULL, -- bộ lọc tìm kiếm
	[ShowOnProductPage] [bit] NOT NULL, -- hiển thị trên trang card
	[DisplayOrder] [int] NOT NULL, -- vị trí hiển thị
	[CreateBy] [int] NOT NULL, -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
--==============================================
-- Name        : 
-- Description : 
-- Date Update : 
--==============================================

