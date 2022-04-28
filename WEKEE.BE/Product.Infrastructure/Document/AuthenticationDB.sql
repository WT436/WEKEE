CREATE DATABASE [AuthorizationDB]	
GO
USE [AuthorizationDB]
GO
-- ====================================================================
---------------------------Miêu tả database----------------------------
-- ====================================================================
-- 0: FALSE, 1 : TRUE
-- ====================================================================
---------------------------Hỗ trợ database-----------------------------
-- ====================================================================
GO
-- ====================================================================
-- Name      :  Ghi lại lịch sử của cả hệ thống
-- Meaning   :  
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [HistoryTable]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL,
	[id_record] INT NOT NULL,
	[data_new] VARCHAR(MAX) NOT NULL,
	[data_old] VARCHAR(MAX) NOT NULL,
--  [action_record] => 0 : CREATE, 1:UPDATE, 2: DELETE, 3:, 4:, 5: 
	[action_record] INT NOT NULL CHECK([action_record]>=0 AND [action_record]<=5),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
--------------------Thông tin tài khoản--------------------------------
-- ====================================================================
GO
-- ====================================================================
-- Name      :  UserProfile
-- Meaning   :  Các hình thức đăng nhập của tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserProfile]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[userName] VARCHAR(100) UNIQUE NOT NULL, -- dùng lưu trữ tài khoản duy nhất
	[email] VARCHAR(254) UNIQUE NOT NULL, -- dùng lưu trữ email
	[numberPhone] VARCHAR(15) NOT NULL, -- số điện thoại
	[isOnline] BIT DEFAULT (1) NOT NULL , -- tài khoản đang online -- 0: FALSE, 1 : TRUE
	[isStatus] INT DEFAULT(0) NOT NULL CHECK([isStatus]>=0 AND [isStatus]<=5),
	-- 0 : tài khoản hoạt động                    -- 1 : tài khoản đang xác nhận đăng ký
	-- 2 : tài khoản đang được lấy lại            -- 3 : tài khoản đang để mất tài khoản
	-- 4 : tài khoản đang đăng nhập sai nhiều lần -- 5 : tài khoản đang checkpoint
	[loginFallNumber] int NOT NULL DEFAULT(0) CHECK([loginFallNumber]>=0 AND [loginFallNumber]<=20), -- số lần đăng nhập thất bại liên tiếp
	[lockAccountTime] datetime NULL,-- thời gian khóa tài khoản
	[is_accept_term] BIT NOT NULL DEFAULT(0), -- 0: FALSE, 1 : TRUE
	[time_zone] VARCHAR(100) NULL,
	[facebookId] VARCHAR(30) NULL,
	[googleId] VARCHAR(30)  NULL,
	[zaloId] VARCHAR(30) NULL,
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  UserAccountStatus
-- Meaning   :  Khôi phục mật khẩu + trạng thái tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserStatus]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[accountId] int FOREIGN KEY REFERENCES [UserProfile]([id]),
	[code] VARCHAR(20) NULL,
	[statusId] INT NOT NULL, -- xác định code lấy lại tài khoản
	[reminderToken] VARCHAR(100) NULL, -- dùng để lưu trữ token khôi phục mật khẩu.
	[reminderExpire] INT NULL, -- thời điểm hết hiệu lực. tính bằng giây
	[updateCount] INT DEFAULT(0) NOT NULL,-- đếm số lần lỗi
	[isActive] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[isDelete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  UserLogin
-- Meaning   :  Lưu mật khẩu
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserPassword]
(
	[id] INT NOT NULL PRIMARY KEY, -- dùng lưu định dạng duy nhất tài khoản
	[AccountId] INT NOT NULL  FOREIGN KEY REFERENCES [UserProfile]([id]),
	[Password] VARCHAR(200) NOT NULL, -- dùng để lưu trữ password
	[PasswordSalt] VARCHAR(50) NOT NULL, --  dùng để lưu trữ chuỗi salt
	[PasswordHashAlgorithm] VARCHAR(50) NOT NULL, -- dùng để lưu thuật toán dùng để hash	
	[isActive] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[isDelete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Theo dõi thiết bị đăng nhập của người dùng
-- Meaning   :  Cho phép đa, đơn thiết bị cùng kết nối trên một tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserIp]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[ipv4] VARCHAR(20) NOT NULL,
	[ipv6] VARCHAR(20) NOT NULL,
	[countryCode] VARCHAR(20) NOT NULL,
	[countryName] VARCHAR(20) NOT NULL,
	[city] VARCHAR(20) NOT NULL,
	[postal] VARCHAR(20) NOT NULL,
	[latitude] VARCHAR(20) NOT NULL,
	[longitude] VARCHAR(20) NOT NULL,
	[state] VARCHAR(20) NOT NULL,
	[userAgent] NVARCHAR(300) NULL,
	[accountId] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- ip máy người dùng khi khởi tạo		
	[updateAcount] INT DEFAULT(0) NOT NULL,
	[isActive] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[isDelete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Địa chỉ người dùng
-- Meaning   :  Lưu địa chỉ người dùng tối đa là 3 địa chỉ
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Address]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[adressLine1] NVARCHAR(256) NOT NULL,-- địa chỉ chính
	[adressLine2] NVARCHAR(256) NULL,-- địa chỉ phụ
	[adressLine3] NVARCHAR(256) NULL,-- địa chỉ phụ	
	[description] NVARCHAR(20) NOT NULL, -- miêu tả
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái -- 0: FALSE, 1 : TRUE
	[accountId] int FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Thông tin của người dùng
-- Meaning   :  Lưu thông tin cá nhân của người dùng khi được cho phép
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [InfomationUser]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[firsName] NVARCHAR(255) NULL,
	[lastName] NVARCHAR(255) NULL,
	[coordinates] VARCHAR(300) NULL, -- tọa độ
	[picture] VARCHAR(200) NULL, -- ảnh
	[gender] INT NOT NULL CHECK([gender] >= 0 AND [gender] <= 3),-- giới tính
	[description] NVARCHAR(20) NOT NULL, -- miêu tả
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[accountId] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Theo dõi đăng nhập
-- Meaning   :  
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [ProcessUser]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[description] NVARCHAR(MAX) NOT NULL, -- mô tả
	[ipUser] VARCHAR(20) NOT NULL, -- ip người dùng
	[isStatus] BIT DEFAULT(0) NOT NULL, -- trạng thái 
	[device] NVARCHAR(100) NOT NULL, -- thiết bị
	[accountId] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
---------------------------Phân quyền----------------------------------
-- ====================================================================
GO
-- ====================================================================
-- Name      :  Thông tin liên quan đến group phân quyền
-- Meaning   :  Nhóm người dùng
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Group]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[nameGroup] NVARCHAR(300) NOT NULL, -- tên nhóm
	[status] INT NOT NULL DEFAULT(0) CHECK([status] >= 0 AND [status] <= 5), -- trạng thái nhóm
	[description] NVARCHAR(MAX) NULL, -- Mô tả
	[introduce] NVARCHAR(MAX) NULL, -- phần giới thiệu
	[groupType] VARCHAR(300) NULL,-- Loại nhóm
	[linkedPages]	VARCHAR(300) NULL,-- Trang được liên kết với nhóm
	[membershipApproval] VARCHAR(300) NULL,-- Duyệt thành viên
	[postApproval] VARCHAR(300) NULL,-- Phê duyệt bài đăng
	[tags] VARCHAR(300) NULL,--Tags
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Chủ thể kết nối
-- Meaning   :  Cổng kết nối chung của tài khoản và nhóm với phân quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Subject]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[userId] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- id người dùng
	[gorupId] INT NULL FOREIGN KEY REFERENCES [Group]([id]) ,-- tên nhóm mà người dùng này đang tham gia
	[isActive] BIT DEFAULT(1) NOT NULL, -- Trạng thái của người dùng trong bộ quyền này
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Chủ thể của nhóm
-- Meaning   :  Kết nối [Group] và [Subject]
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [SubjectGroup]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] NVARCHAR(300) NOT NULL, -- Tên 
	[gorupId] INT FOREIGN KEY REFERENCES [Group]([id]) NOT NULL,
	[subjectId] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL,
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Vai trò
-- Meaning   :  Quản lý các vai trò chính của nhóm và người dùng cá nhân, ví dụ như giám đốc là một vao trò và giám đốc các các quyền khác nhau
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Role]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(30) NOT NULL, -- tên vai trò
	[description] NVARCHAR(MAX) NOT NULL, -- mô tả	
	[levelRole] INT DEFAULT(0) CHECK([levelRole]>= 0) NOT NULL,
	[roleManageId] INT FOREIGN KEY REFERENCES [Role]([id])  NOT NULL, -- vai trò quản lý	
	[isDelete] BIT DEFAULT(0) NOT NULL,
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Phân công cho vai trò
-- Meaning   :  Chi tiết của từng vai trò đó là nhiều quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [SubjectAssignment]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[roleId] INT FOREIGN KEY REFERENCES [Role]([id]) NOT NULL ,
	[subjectId] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL ,
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Hành động cụ thể
-- Meaning   :  Các hành động như GET,WATCH,UPDATE,.... của Table , access ... của các hàm, access của các URL
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Atomic]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(300) NOT NULL, -- tên phần tử của quyền
	[description] NVARCHAR(MAX) NOT NULL,
	[typesRsc] INT NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Nguồn gốc, tài nguyên
-- Meaning   :  Namespace, url, function, ...... cụ thể
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Resource]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY ,
	[name] NVARCHAR(300) UNIQUE NOT NULL, -- lưu trữ các bảng
	[typesRsc] INT NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[description] NVARCHAR(MAX) NOT NULL,
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO

GO
-- ====================================================================
-- Name      :  Cho phép quyền của vai trò
-- Meaning   :  Các quyền sẽ nằm ở đây
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
-- nguông cung cấp chính cho vai trò  
-- các action sẽ được chỉ định và tương tác ở đây
CREATE TABLE [Permission]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,	
	[name] VARCHAR(300) NOT NULL,-- tên quyền
	[description] NVARCHAR(MAX) NOT NULL, -- mô tả
	[AtomicId] INT FOREIGN KEY REFERENCES [Atomic]([id]) NOT NULL ,
	[levelPermition] INT DEFAULT(0) CHECK([levelPermition]>=0) NOT NULL,
	[permissionId] INT FOREIGN KEY REFERENCES [Permission]([id]) NULL ,
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Phân công từng thành phần cho các quyền được cho phép
-- Meaning   :  Các quyền của một vai trò
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [PermissionAssignment]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[roleId] INT FOREIGN KEY REFERENCES [Role]([id]) NOT NULL ,
	[permissionId] INT FOREIGN KEY REFERENCES [Permission]([id]) NOT NULL ,
	[isActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO

CREATE TABLE [ReourceAssignment]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[resourceId] INT FOREIGN KEY REFERENCES [Resource]([id]) NOT NULL ,
	[permissionId] INT FOREIGN KEY REFERENCES [Permission]([id]) NOT NULL ,
	[isActive] BIT DEFAULT(1) NOT NULL, 
	[CreateBy] INT NOT NULL DEFAULT(0), 
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)