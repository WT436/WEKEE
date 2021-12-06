CREATE DATABASE [SupplierDB]
GO
USE [SupplierDB]
GO
/******    Nhà cung Cấp     ******/
CREATE TABLE [Supplier](
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[fullName] NVARCHAR(30) NOT NULL,
	[numberPhone] numeric(14, 0) NOT NULL,
	[email] VARCHAR(300) NOT NULL,
	[passWordShop] VARCHAR(100) NOT NULL,
	[haskPass] VARCHAR(10) NOT NULL,
	[nameShop] NVARCHAR(300) NOT NULL,
	[linkShop] NVARCHAR(300) NOT NULL,
	[adress] NVARCHAR(300) NOT NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isActive] BIT NOT NULL  DEFAULT (0), -- nhà cung cấp tạm nghỉ
	[isEnabled] BIT NOT NULL  DEFAULT (0), -- xóa bỏ  nhà cung cấp
--=========>Connect Table<===========--
	[use_account] INT,
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
CREATE TABLE [repositoryCertificate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL  primary key,
	[title] NVARCHAR(50) NOT NULL,
	[htmlCertificate] NVARCHAR(max) NOT NULL,
	[imageCertificate] VARCHAR(max) NOT NULL,
	[descrpition] NVARCHAR(50),
	[dateCreate] DATETIME NOT NULL DEFAULT GETDATE(),
	[isEnabled] BIT NULL  DEFAULT (0)
--=========>Connect Table<===========--
)
GO
/******  các loại giấy chứng nhận cho nhà cung cấp Nhà cung Cấp     ******/
CREATE TABLE [supplierCertificate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL  primary key ,
	[dateCreate] DATETIME NOT NULL DEFAULT GETDATE(),
	[isLevel] INT DEFAULT 0 CHECK(isLevel<7) NOT NULL, -- phân chia loại giấy ra làm 6 cấp độ : không có , cực khủng , Tuyệt vời , Tốt , Vừa , Thấp , Kém
	[isEnabled] BIT NULL  DEFAULT (0),
--=========>Connect Table<===========--
	[idSupper] INT NOT NULL FOREIGN KEY REFERENCES Supplier(id),
	[idCertificate] INT NOT NULL FOREIGN KEY REFERENCES repositoryCertificate(id),
)
GO