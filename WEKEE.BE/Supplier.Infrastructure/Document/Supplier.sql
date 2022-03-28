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
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[UpdatedOnUtc] [datetime2](7) NOT NULL,
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