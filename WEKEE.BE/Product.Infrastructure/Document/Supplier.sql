CREATE DATABASE [SupplierDB]
GO
USE [SupplierDB]
GO
/******    Nhà cung Cấp     ******/
CREATE TABLE [Supplier](
--=========>Trường Dữ Liệu<===========--
	[Id] INT IDENTITY(1,1) NOT NULL primary key,
	[NumberPhone] numeric(14, 0) NULL,
	[Email] VARCHAR(300) NULL,
	[PassWordShop] VARCHAR(100) NOT NULL,
	[HaskPass] VARCHAR(10) NOT NULL,
	[NameShop] NVARCHAR(300) NOT NULL,
	[LinkShop] NVARCHAR(300) NOT NULL,
	[Adress] NVARCHAR(300) NULL,
	[Url] [nvarchar](400) NULL,
	[Hosts] [nvarchar](1000) NULL,
	[CompanyVat] [nvarchar](1000) NULL,
	[SslEnabled] [bit] NULL,
	[DefaultLanguageId] [int] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT (GETDATE()),
	[IsActive] BIT NULL  DEFAULT (0), -- nhà cung cấp tạm nghỉ
	[IsEnabled] BIT NULL  DEFAULT (0), -- xóa bỏ  nhà cung cấp
)
GO
-- map nhân viên và store
CREATE TABLE [SupplierMapping](
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[SupplierId] INT NOT NULL FOREIGN KEY REFERENCES Supplier(id),
	[UseAccount] INT NOT NULL,
	[IsBoss] BIT DEFAULT(0),
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL DEFAULT (GETDATE()),
	[UpdatedOnUtc] [datetime2](7) NOT NULL DEFAULT (GETDATE()),
)
GO
/******   Gian Hàng Nhà cung cấp  ******/
CREATE TABLE [ShopSupplier]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[logo] VARCHAR(200) NOT NULL,
	[background] VARCHAR(200) NOT NULL,
	[descrpition] NVARCHAR(500),
	[follow] INT DEFAULT (0) NOT NULL,
--=========>Connect Table<===========--
	[supplier] INT NULL FOREIGN KEY REFERENCES Supplier(id),
	[seo] INT,
)
GO
/******    Carousel *****/
CREATE TABLE [CarouselSupplier]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT NOT NULL primary key,
	[link] NVARCHAR(300) NULL,
	[title] NVARCHAR(300) NULL,
	[carouselImage] VARCHAR(max),
	[position] INT NOT NULL,
	[isEnabled] BIT DEFAULT 0,
--=========>Connect Table<===========--
	[shopSupplier] INT NULL foreign key references ShopSupplier(Id)	
)
GO
/****** Kho các loại giấy chứng nhận cho nhà cung cấp Nhà cung Cấp  ******/
CREATE TABLE [RepositoryCertificate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL  primary key,
	[title] NVARCHAR(50) NOT NULL,
	[htmlCertificate] NVARCHAR(max) NOT NULL,
	[imageCertificate] VARCHAR(max) NOT NULL,
	[descrpition] NVARCHAR(50),
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[isEnabled] BIT NULL  DEFAULT (0)
--=========>Connect Table<===========--
)
GO
/******  các loại giấy chứng nhận cho nhà cung cấp Nhà cung Cấp     ******/
CREATE TABLE [SupplierCertificate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL  primary key ,
	[CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
	[isLevel] INT DEFAULT 0 CHECK(isLevel<7) NOT NULL,
	[isEnabled] BIT NULL  DEFAULT (0),
--=========>Connect Table<===========--
	[idSupper] INT NOT NULL FOREIGN KEY REFERENCES Supplier(id),
	[idCertificate] INT NOT NULL FOREIGN KEY REFERENCES repositoryCertificate(id),
)
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [nvarchar](max) NULL,
	[IncludeInSitemap] [bit] NOT NULL,
	[IncludeInTopMenu] [bit] NOT NULL,
	[IncludeInFooterColumn1] [bit] NOT NULL,
	[IncludeInFooterColumn2] [bit] NOT NULL,
	[IncludeInFooterColumn3] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[AccessibleWhenStoreClosed] [bit] NOT NULL,
	[IsPasswordProtected] [bit] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[Published] [bit] NOT NULL,
	[TopicTemplateId] [int] NOT NULL,
	[MetaKeywords] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL
)
GO
CREATE TABLE [dbo].[StorePickupPoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
	[PickupFee] [decimal](18, 4) NOT NULL,
	[OpeningHours] [nvarchar](max) NULL,
	[DisplayOrder] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[Latitude] [decimal](18, 4) NULL,
	[Longitude] [decimal](18, 4) NULL,
	[TransitDays] [int] NULL
)