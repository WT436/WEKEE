CREATE DATABASE [ProductDB]
GO
USE [ProductDB]
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< CHỦ ĐỀ LOẠI CHỦ ĐỀ TAG >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Danh Mục sản phẩm    ******/
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
	[CreatedAt] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NOT NULL DEFAULT (GETDATE())
--=========>Connect Table<===========--
)
GO
/******    Thông số kỹ thuật sản phẩm    ******/
CREATE TABLE [SpecificationsCategory] (
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
	[key] NVARCHAR(200) NOT NULL, -- mã thông số kỹ thuật không chứa khoảng cách
	[nameShow] NVARCHAR(200) NOT NULL, -- tên hiển thị
	[classify] INT NOT NULL CHECK([classify] > 0), 
	-- 1: Phân loại hàng hóa
	-- 2: Thông số hàng hóa
	-- 3: Đơn vị tính cho sản phẩm
	-- 4: Thương hiểu sản phẩm
	-- 5: 
	-- 6:
	-- 7:
	-- 8:
	[classifyValues] NVARCHAR(200)  NULL, -- giá trị của phân loại
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[CreatedAt] DATETIME NOT NULL DEFAULT (GETDATE()),
	[categoryMain] INT NULL foreign key references [CategoryProduct]([id])
--=========>Connect Table<===========--
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< SEO CHO SẢN PHẨM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/*seo cho tất cả dữ liệu  liên quan đến truy vấn hay index cho gg*/
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
--=========>Connect Table<===========--
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< SẢN PHẨM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Sản Phẩm     ******/
CREATE TABLE [Product]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[name] NVARCHAR(100) NOT NULL,--*
    [unitProduct] INT FOREIGN KEY REFERENCES [SpecificationsCategory] (id),	-- đơn vị tính cho product 
	[fragile] BIT DEFAULT 0 , -- Hàng Dễ Vỡ 
	[origin] NVARCHAR(300), -- Nguồn Gốc *
	[trademark] INT FOREIGN KEY REFERENCES [SpecificationsCategory] (id), -- Thương Hiệu
	[introduce] NVARCHAR(MAX) NULL,-- Giới thiệu *
	[tag] NVARCHAR(300) NOT NULL, -- 
	[CreatedAt] DATETIME DEFAULT GETDATE(), -- *
	[UpdatedAt] DATETIME DEFAULT GETDATE(),-- *
	[isStatus]  INT DEFAULT 0 CHECK([isStatus]<3 AND [isStatus]>-1), -- 0 là thông tin chưa đầy đủ,  1 là chưa được đăng, 3 --*
	[isEnabled] BIT NOT NULL DEFAULT (0), --*
--=========>Connect Table<===========--
	[supplier] INT , -- nhà cung cấp --*
	[categoryProduct] INT NULL FOREIGN KEY REFERENCES [CategoryProduct](id),-- chủ đề sản phẩm --*
	[productAlbum] NVARCHAR(200) NOT NULL DEFAULT('highlights'),-- album sản phẩm --*
	[seo] INT FOREIGN KEY REFERENCES Seo (id),-- seo --*
)
GO
/******    Ảnh Sản Phẩm    ******/
CREATE TABLE [ImageProduct]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[src] VARCHAR(max) NOT NULL,-- là đường dẫn ảnh
	[alt] NVARCHAR(300) NOT NULL,
	[title] NVARCHAR(300) NOT NULL,
	[size] VARCHAR(20) NOT NULL,
	[folder] VARCHAR(50) NOT NULL,
	[imageRoot] INT FOREIGN KEY REFERENCES [ImageProduct] (id),
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[isCover] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL FOREIGN KEY REFERENCES [Product] (id)
)
GO
/******  Danh Sách  Sản Phẩm cùng loại    ******/
CREATE TABLE [FeatureProduct]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[price] DECIMAL(19,0) NOT NULL, -- giá tại đây --*
	[price_market] DECIMAL(19,0) NOT NULL, -- giá thực tế
	[total_number] INT NULL,-- tổng sản phẩm
	[key1] INT NULL FOREIGN KEY REFERENCES [SpecificationsCategory] (id), -- tên hiển thị phân loại 1
	[properties1] NVARCHAR(50) NOT NULL, -- thuộc tính 1
	[key2] INT NULL FOREIGN KEY REFERENCES [SpecificationsCategory] (id), -- tên hiển thị phân loại 2
	[properties2] NVARCHAR(50) NOT NULL, -- thuộc tính 2
	[vat] DECIMAL(19,0) , -- thuế vat
	[mass] FLOAT , --  khối lượng
	[volume] FLOAT , -- thể tích
	[guarantee] FLOAT NOT NULL, -- bảo hành
	[CreatedAt] DATETIME DEFAULT GETDATE(),
	[UpdatedAt] DATETIME DEFAULT GETDATE(),
	[isDefault] BIT DEFAULT 0,
	[isStatus]  INT DEFAULT 0,
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL FOREIGN KEY REFERENCES Product (id),
	[imageProduct] INT NULL FOREIGN KEY REFERENCES [ImageProduct] (id)
)
GO
/******    Bài viết Sản phẩm  X  ****/
CREATE TABLE [DescriptionProduct]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[blog] NVARCHAR(max) DEFAULT (N'Chưa có bào viết nào về sản phẩm này ,quý khách vui lòng quay lại sau ') NOT NULL,
	[viewProduct] INT DEFAULT 0 NOT NULL,
	[likePost] INT DEFAULT 0 NOT NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL FOREIGN KEY REFERENCES Product (Id),
	[use_account] INT,
)
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< CHI TIẾT SẢN PHẨM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******  Danh Sách thông số Sản Phẩm    ******/
CREATE TABLE [HighlightProduct]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[key] INT NOT NULL FOREIGN KEY REFERENCES [SpecificationsCategory] (id), -- tên trường dạng chuẩn pascalCode
	[values] NVARCHAR(300) NOT NULL, -- giá trị của trường
	[displayOrder] INT NOT NULL, -- vị trí hiển thị của trường
	[CreatedAt] DATETIME DEFAULT GETDATE(),
	[UpdatedAt] DATETIME DEFAULT GETDATE(),
	[isStatus]  INT DEFAULT 0,
--=========>Connect Table<===========--
	[product] INT NULL FOREIGN KEY REFERENCES Product (id),
)
