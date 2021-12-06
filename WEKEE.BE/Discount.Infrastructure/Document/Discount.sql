CREATE DATABASE [DiscountDB]
GO
USE [DiscountDB]
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< CHƯƠNG TRÌNH GIẢM GIÁ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Giảm Giá  X   ******/ -- có những mã giảm giác đặc biệt cho các sản phẩm khác nhau của 1 nhà cung cấp
CREATE TABLE [Discount]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[code] NVARCHAR(10) NOT NULL,
	[percent] INT NOT NULL, -- phần trăm
	[moneyMax]  MONEY NOT NULL, -- số tiền tối đa
	[dateCreate] DATETIME NULL DEFAULT (GETDATE()),
	[dateEnd] INT NULL DEFAULT ((15)),
	[numberUsing] INT NULL DEFAULT (0), -- số lần được sửa dụng
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[supplier] INT-- nhà cung cấp tạo mã giảm giá cho chính ,mình
)
GO
/******    Sản phẩm sử dụng giảm giá   ******/ -- nhà cung cấp cài đặt mã giảm giá họ tạo cho san phẩm của họ
CREATE TABLE [ProductUseDiscount]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[number] INT not NULL,	
	[dateCreate] date DEFAULT GETDATE() not null,
	[dateEnd] INT DEFAULT 120 not null,
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL,
	[discount] INT NULL FOREIGN KEY REFERENCES Discount (id),
)
GO
/******    Giảm giá chi tiết từ người dùng   ******/
CREATE TABLE [DetailDiscountFromUser]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[number] INT NULL,	
	[dateCreate] DATETIME NULl DEFAULT GETDATE(),
	[number_incorrect] INT ,
	[success] BIT ,
	[isEnabled] BIT NOT NULL DEFAULT (0), -- nếu như nhập không thành công thì lần sau người dùng này nhập lại sẽ up lại cái bản này
--=========>Connect Table<===========--
	[use_account] INT,
	[productUseDiscount] INT NULL FOREIGN KEY REFERENCES ProductUseDiscount (Id),
)
GO
/******    Kho lưu trữ khuyến mãi   ******/
CREATE TABLE [promotionReposetory]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[total_number] INT NULL,
	[dateCreate] DATETIME DEFAULT GETDATE() not null,
	[dateEnd] INT DEFAULT 120 not null,
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL ,
	[supplier] INT NULL -- nhà cung cấp tạo khuyến mãi cho chính mình và sử dụng sản phẩm của mình
)
GO
/******    khuyến mãi     ******/
CREATE TABLE [promotion]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[remainingNumber] INT NULL,
	[number] INT NULL,
	[discount] INT null,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] INT NOT NULL DEFAULT (120),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT,
	[promotionReposetory] INT  FOREIGN KEY REFERENCES promotionReposetory (id),
)
GO
/******    Lịch sử người dùng khuyến mãi    ***/
CREATE TABLE [promotionHistory]
( -- đầu tien nó sẽ vào đây , khi nó nhận được thằng id của sản phẩm nó sẽ lên bảng  đếm số ak lộn
							   -- lên bảng Kho lưu trữ khuyến mãi , và nó sẽ xác định được các mức và các sản phẩm  kèm theo .
							   -- sau đó khi có tất cả rồi chúng sẽ được tổng hợp vào bảng này 
							   -- sau đó người dùng sẽ dịch chuyển tùy ý dự trên dữ liệu có sẵn , tính tiền hoàn tiền .....
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[receivedNumber] INT , -- số sản phẩm mà khách muốn có 
	[cancelNumber] INT , -- số sản phẩm mà khách từ chối hiểu
	[reductionAmount] INT,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()), -- thời gian mà khách tạo cái củ lìn này
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[use_account] INT,
	[promotionReposetory] INT  FOREIGN KEY REFERENCES promotionReposetory (Id), -- Kho lưu trữ khuyến mãi là INTerface cho tất cacr nhưng table khác thêm vị trí của nó vào
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TÀI NGUYÊN MẶC ĐỊNH >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******   kho giá địa chỉ  Ship hàng  *****/
CREATE TABLE [moneyShip]
(
	[id] INT IDENTITY(1,1) primary key,
	[diaDiem1] NVARCHAR(50),
	[diaDiem2] NVARCHAR(50),
	[khoiLuong] INT ,
	[theTich] INT ,
	[giaGiaoBinhThuong] INT ,
	[giaGiaoNhanh] INT ,
	[giaGiaoSieuToc] INT ,
	[isEnabled] BIT DEFAULT 0
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< NGƯỜI DÙNG MUA HÀNG >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    giỏ hàng    *****/
CREATE TABLE [Cart]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,	
	[number] INT NOT NULL CHECK  ((number>(0))),
	[freightPrice] INT, -- giá vận chuyển
	[totalDiscount] INT CHECK(totalDiscount>0 and totalDiscount<100),
	[endPrice] INT,
	[dateCreate] DATETIME DEFAULT GETDATE(),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL ,-- các sản phẩm kèm theo , tặng kèm 
	[listProduct] INT NULL ,-- các sản phẩm kèm theo , tặng kèm 
	[promotionHistory] INT NULL FOREIGN KEY REFERENCES promotionHistory(id),-- các sản phẩm kèm theo , tặng kèm 
	[detailDiscountFromUser] INT NULL FOREIGN KEY REFERENCES DetailDiscountFromUser(Id), --giảm gía khi người dùng nhập vào
	[moneyShip] INT NULL FOREIGN KEY REFERENCES MONEYShip(id),--tiền ship mặt hàng này
	[use_account] INT,-- tài khoản người dùng
)
GO

/******    Thanh Toán   **/
CREATE TABLE [Pay]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[tongtien] numeric(18, 0) NOT NULL DEFAULT (0),
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isStatus] BIT not null DEFAULT 1 CHECK(isStatus < 5), 
	-- 0 : Thanh toán tiền mặt khi nhận hàng (COD)
	-- 1 : Thanh toán qua thẻ ATM có đăng ký thanh toán trực tuyến 
	-- 2 : Thanh toán qua thẻ Visa/Master/JCB
	-- 3 : Thanh toán qua ví MoMo
	-- 4 : Thanh toán qua ZaloPay
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[cart] INT NULL FOREIGN KEY REFERENCES Cart(Id), -- sản phẩm đã mua
)
GO
/******    Mua sản Phẩm    *****/
CREATE TABLE [Purchase]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[dateOrder] DATETIME NOT NULL DEFAULT (GETDATE()),
	[ngayGiao] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isStatus] BIT not null DEFAULT 1 CHECK(isStatus < 7), 
	-- 0 : sản phẩm đã xóa khác với sản phẩm giao thành công
	-- 1 : trạng thái đóng gói hàng và chuẩn bị giao dự kiến
	-- 2 : đang trên đường vận chuyển , cái củ lìn này mai sau sẽ tích hợp hệ thống theo dõi từ xa và ship 
	-- 3 : giao hàng thành công
	-- 4 : sản phẩm bị trả về
	-- 5 : sản phẩm bị hủy giữa trừng
	-- 6 : sản phẩm đã giao
--=========>Connect Table<===========--
	[cart] INT NULL FOREIGN KEY  REFERENCES Cart (Id),-- lấy tất cả thông tin mà khách hàng mặc định bên giỏ hàng và đóng gói gửi cho khách
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< HỢP ĐỒNG KẾT NỐI >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Mẫu hợp đồng   ***/
CREATE TABLE ContractForm(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[html] NVARCHAR(max) NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[use_account] INT,
)
GO
/******    hợp đồng   ****/
CREATE TABLE [IsContract]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[html] NVARCHAR(max) NULL,
--=========>Connect Table<===========--
	[use_account] INT,
	[contractForm] INT NULL  FOREIGN KEY  REFERENCES ContractForm (Id),
	[purchase] INT NULL FOREIGN KEY REFERENCES Purchase (Id),
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TRẠNG THÁI SẢN PHẨM SAU MUA >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******   Sản phẩm Thất Bại   *****/
CREATE TABLE [FailureProduct]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[reason] NVARCHAR(300) ,
	[isEnabled] BIT NOT NULL DEFAULT (0),
--==[=======>Connect Table<===========--
	[purchase] INT NULL FOREIGN KEY REFERENCES Purchase (Id),
	[isContract] INT NULL FOREIGN KEY REFERENCES IsContract (Id),
	[pay] INT NULL FOREIGN KEY REFERENCES Pay (Id),
)
GO
/******    Bảo hành    ****/
CREATE TABLE [Guarantee]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[purchase] INT NULL FOREIGN KEY REFERENCES Purchase (Id),
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ĐÁNH GIÁ SẢN PHẨM >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Đánh giá X  ****/
CREATE TABLE [Evaluate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[noIdung] NVARCHAR(max) NOT NULL,
	[soSao] INT NULL DEFAULT ((3)) CHECK  ((soSao>(0) AND soSao<(6))),
	[imageEvaluate] VARCHAR(max),
	[thoiGian] DATETIME NULL DEFAULT (GETDATE()),
--=========>Connect Table<===========--
	[product] INT NULL,
	[use_account] INT,
)
GO
/******    Rep Đánh giá  X  *****/
CREATE TABLE [RepEvaluate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[noIdung] NVARCHAR(max) NOT NULL,
	[thoiGian] DATETIME NULL DEFAULT (GETDATE()),
	[imageEvaluate] VARCHAR(max),
--=========>Connect Table<===========--
	[evaluate] INT NULL FOREIGN KEY REFERENCES Evaluate (Id),
	[use_account] INT,
)
GO
/******    Like Đánh giá  X  *****/
CREATE TABLE [LikeEvaluate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[islike] BIT NULL,
	[dislike] BIT NULL,
	[thoiGian] DATETIME NULL DEFAULT (GETDATE()),
--=========>Connect Table<===========--
	[evaluate] INT NULL FOREIGN KEY REFERENCES Evaluate (Id),
	[use_account] INT,
)
GO
/******    Like Rep Đánh giá  X ****/
CREATE TABLE [LikeRepEvaluate]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[islike] BIT NULL,
	[dislike] BIT NULL,
	[thoiGian] DATETIME NULL DEFAULT (GETDATE()),
--=========>Connect Table<===========--
	[repEvaluate] INT NULL FOREIGN KEY REFERENCES RepEvaluate (Id),
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ƯU ĐÃI NGƯỜI DÙNG >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Kho XU    ****/
CREATE TABLE [RepositoryXu]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[xu] INT NULL,
	[mucgiaMin] numeric(18, 0) NULL,
	[mucgiaMax] numeric(18, 0) NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[use_account] INT,
)
GO
/******    Sản Phẩm Sảu dụng xu   *****/
CREATE TABLE [ProductUsingXu]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NOT NULL DEFAULT (GETDATE()),
	[saoDanhGia] float NULL,
	[soXu] INT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[product] INT NULL,
	[repositoryXU] INT NULL FOREIGN KEY REFERENCES RepositoryXU (Id),
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< CHƯƠNG TRÌNH KHUYẾN MÃI >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Phiếu giảm giá    ****/
CREATE TABLE [CouponsAndCents]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[xuMin] INT NULL,
	[xuMax] INT NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[discount] INT NULL FOREIGN KEY REFERENCES Discount (Id),
	[use_account] INT,
)
GO
/******    Lịch sử nhận Coins    *****/
CREATE TABLE [HistoryOfReceivingCoins]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[soXu] INT NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] DATETIME NOT NULL DEFAULT (GETDATE()),
	[isEnabled] BIT NOT NULL DEFAULT (0),
--=========>Connect Table<===========--
	[discount] INT NULL FOREIGN KEY REFERENCES Discount (Id),
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ĐONG ĐẾM NGƯỜI DÙNG >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/******    Sản phẩm đã xem  v  ***/
CREATE TABLE [ProductView]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[numberView] INT NOT NULL,
	[timeCreate] DATETIME NOT NULL,
	[dateEnd] DATETIME NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[IpClient] NVARCHAR(50) ,
--=========>Connect Table<===========--
	[product] INT NULL,
	[use_account] INT,
)
GO

/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< QUẢNG CÁO CỦA TÔI >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Quảng cáo  v  ****/
CREATE TABLE [Advertisement]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT IDENTITY(1,1) NOT NULL primary key,
	[imageRieng] VARCHAR(MAX) NULL,
	[link] NVARCHAR(50) NULL,
	[dateCreate] DATETIME NOT NULL DEFAULT (GETDATE()),
	[dateEnd] INT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[noiDung] NVARCHAR(100) NULL,
--=========>Connect Table<===========--
	[product] INT NULL,
	[use_account] INT,
)
GO
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
/*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LIÊN KẾT TRANG >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/
/*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
GO
/******    Carousel v  *****/
CREATE TABLE [Carousel]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT NOT NULL primary key IDENTITY(1,1),
	[link] NVARCHAR(300) NULL,
	[title] NVARCHAR(300) NULL,
--=========>Connect Table<===========--
	[product] INT NULL ,
	[MainCarousel] INT NULL FOREIGN KEY REFERENCES Carousel (Id),
	[isEnabled] BIT DEFAULT 0
)
GO
/******    advertisement v  *****/
CREATE TABLE [AdvertisementHome]
(
--=========>Trường Dữ Liệu<===========--
	[id] INT NOT NULL primary key IDENTITY(1,1),
	[link] NVARCHAR(300) NULL,
	[product] INT NULL ,
	[link2] NVARCHAR(300) NULL,
	[product2] INT NULL ,
	[link3] NVARCHAR(300) NULL,
	[product3] INT NULL,
	[link4] NVARCHAR(300) NULL,
	[product4] INT NULL,
	[link5] NVARCHAR(300) NULL,
	[product5] INT NULL,
--=========>Connect Table<===========--
	[isEnabled] BIT DEFAULT 0,
	[DateCreate] DATETIME not null DEFAULT(GETDATE())
)
GO