CREATE DATABASE [Authorization]	
GO
USE [Authorization]
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
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[is_accept_term] BIT NOT NULL DEFAULT(0), -- 0: FALSE, 1 : TRUE
	[time_zone] VARCHAR(100) NULL,
	[facebook_id] VARCHAR(30) NULL,
	[google_id] VARCHAR(30)  NULL,
	[zalo_id] VARCHAR(30) NULL,
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  UserAccountStatus
-- Meaning   :  Khôi phục mật khẩu + trạng thái tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserAccountStatus]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[account_id] int FOREIGN KEY REFERENCES [UserProfile]([id]),
	[code] VARCHAR(20) NULL,
	[status_id] INT NOT NULL, -- xác định code lấy lại tài khoản
	[reminder_token] VARCHAR(100) NULL, -- dùng để lưu trữ token khôi phục mật khẩu.
	[reminder_expire] INT NULL, -- thời điểm hết hiệu lực. tính bằng giây
	[update_count] INT DEFAULT(0) NOT NULL,-- đếm số lần lỗi
	[is_active] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[is_delete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  UserLogin
-- Meaning   :  Đăng nhập bằng mật khẩu
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserLogin]
(
	[id] INT NOT NULL PRIMARY KEY 
					  FOREIGN KEY REFERENCES [UserProfile]([id]), -- dùng lưu định dạng duy nhất tài khoản
	[user_name] VARCHAR(100) UNIQUE NOT NULL, -- dùng lưu trữ tài khoản duy nhất
	[login_fall_number] int NOT NULL DEFAULT(0) CHECK([login_fall_number]>=0 AND [login_fall_number]<=20), -- số lần đăng nhập thất bại liên tiếp
	[lock_account_time] datetime NULL,-- thời gian khóa tài khoản
	[email] VARCHAR(254) UNIQUE NOT NULL, -- dùng lưu trữ email
	[number_phone] VARCHAR(15) NOT NULL, -- số điện thoại
	[password] VARCHAR(200) NOT NULL, -- dùng để lưu trữ password
	[password_salt] VARCHAR(50) NOT NULL, --  dùng để lưu trữ chuỗi salt
	[password_hash_algorithm] VARCHAR(50) NOT NULL, -- dùng để lưu thuật toán dùng để hash		
	[is_online] BIT DEFAULT (1) NOT NULL , -- tài khoản đang online -- 0: FALSE, 1 : TRUE
	[is_status] INT DEFAULT(0) NOT NULL CHECK([is_status]>=0 AND [is_status]<=5),
	-- 0 : tài khoản hoạt động                    -- 1 : tài khoản đang xác nhận đăng ký
	-- 2 : tài khoản đang được lấy lại            -- 3 : tài khoản đang để mất tài khoản
	-- 4 : tài khoản đang đăng nhập sai nhiều lần -- 5 : tài khoản đang checkpoint
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Theo dõi thiết bị đăng nhập của người dùng
-- Meaning   :  Cho phép đa, đơn thiết bị cùng kết nối trên một tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserAccountIp]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[ipv4] VARCHAR(20) NOT NULL,
	[country_code] VARCHAR(20) NOT NULL,
	[country_name] VARCHAR(20) NOT NULL,
	[city] VARCHAR(20) NOT NULL,
	[postal] VARCHAR(20) NOT NULL,
	[latitude] VARCHAR(20) NOT NULL,
	[longitude] VARCHAR(20) NOT NULL,
	[state] VARCHAR(20) NOT NULL,
	[user_agent] NVARCHAR(300) NULL,
	[account_id] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- ip máy người dùng khi khởi tạo		
	[update_acount] INT DEFAULT(0) NOT NULL,
	[is_active] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[is_delete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[adress_line_1] NVARCHAR(256) NOT NULL,-- địa chỉ chính
	[adress_line_2] NVARCHAR(256) NULL,-- địa chỉ phụ
	[adress_line_3] NVARCHAR(256) NULL,-- địa chỉ phụ	
	[description] NVARCHAR(20) NOT NULL, -- miêu tả
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái -- 0: FALSE, 1 : TRUE
	[account_id] int FOREIGN KEY REFERENCES [UserProfile]([id]),
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[first_name] NVARCHAR(255) NULL,
	[last_name] NVARCHAR(255) NULL,
	[full_name] NVARCHAR(255) NULL,
	[coordinates] VARCHAR(300) NULL, -- tọa độ
	[picture] VARCHAR(200) NULL, -- ảnh
	[gender] INT NOT NULL CHECK([gender] >= 0 AND [gender] <= 3),-- giới tính
	[description] NVARCHAR(20) NOT NULL, -- miêu tả
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[account_id] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[ip_user] VARCHAR(20) NOT NULL, -- ip người dùng
	[is_status] BIT DEFAULT(0) NOT NULL, -- trạng thái 
	[device] NVARCHAR(100) NOT NULL, -- thiết bị
	[account_id] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[name_group] NVARCHAR(300) NOT NULL, -- tên nhóm
	[status] INT NOT NULL DEFAULT(0) CHECK([status] >= 0 AND [status] <= 5), -- trạng thái nhóm
	[description] NVARCHAR(MAX) NULL, -- Mô tả
	[introduce] NVARCHAR(MAX) NULL, -- phần giới thiệu
	[group_type] VARCHAR(300) NULL,-- Loại nhóm
	[linked_pages]	VARCHAR(300) NULL,-- Trang được liên kết với nhóm
	[membership_approval] VARCHAR(300) NULL,-- Duyệt thành viên:
	[post_approval] VARCHAR(300) NULL,-- Phê duyệt bài đăng
	[tags] VARCHAR(300) NULL,--Tags
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[user_id] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- id người dùng
	[gorup_id] INT FOREIGN KEY REFERENCES [Group]([id]) NULL,-- tên nhóm mà người dùng này đang tham gia
	[is_active] BIT DEFAULT(1) NOT NULL, -- Trạng thái của người dùng trong bộ quyền này
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[gorup_id] INT FOREIGN KEY REFERENCES [Group]([id]) NOT NULL,
	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL,
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[level_role] INT DEFAULT(0) CHECK([level_role]>=0) NOT NULL,
	[role_id] INT FOREIGN KEY REFERENCES [Role]([id])  NOT NULL, -- vai trò chủ đạo	
	[is_delete] BIT DEFAULT(0) NOT NULL,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[role_id] INT FOREIGN KEY REFERENCES [Role]([id]) NOT NULL ,
	[subject_id] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL ,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
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
-- quyền
CREATE TABLE [Permission]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,	
	[name] VARCHAR(300) NOT NULL,-- tên quyền
	[description] NVARCHAR(MAX) NOT NULL, -- mô tả
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[role_id] INT FOREIGN KEY REFERENCES [Role]([id]) NOT NULL ,
	[permission_id] INT FOREIGN KEY REFERENCES [Permission]([id]) NOT NULL ,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Ràng buộc vào ủy quyền
-- Meaning   :  Thuật toán cách lấy ..... của quyền vào namespace
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [AuthorizationConstraint]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] NVARCHAR(300) NOT NULL, -- tên logic quyền
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Nhiệm vụ của ràng buộc ủy quyền
-- Meaning   :  Định danh và thuật toán của quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [ConstraintAssignment]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[permission_id] INT FOREIGN KEY REFERENCES [Permission]([id]) NOT NULL ,
	[authorizationConstraint_id] INT FOREIGN KEY REFERENCES [AuthorizationConstraint]([id]) NOT NULL ,	
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
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
	[types_rsc] VARCHAR(300) NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
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
	[id] INT IDENTITY(1,1) CONSTRAINT [PK__Resource__3213E83FB3983A2E] PRIMARY KEY CLUSTERED,
	[name] NVARCHAR(300) UNIQUE NOT NULL, -- lưu trữ các bảng
	[types_rsc] VARCHAR(300) NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[description] NVARCHAR(MAX) NOT NULL,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Hành động
-- Meaning   :  Hành động của quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Action]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[name] NVARCHAR(300) NOT NULL, -- hành động của quyền
	[atomic_id] INT FOREIGN KEY REFERENCES [Atomic]([id]) NOT NULL ,
	[description] NVARCHAR(MAX) NOT NULL,
	[action_base] INT FOREIGN KEY REFERENCES [Action]([id]) NULL,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Phân công cho hành động
-- Meaning   :  Các hành động của quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [ActionAssignment]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[permission_id] INT FOREIGN KEY REFERENCES [Permission]([id]) NOT NULL ,
	[action_id] INT FOREIGN KEY REFERENCES [Action]([id]) NOT NULL,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO
-- ====================================================================
-- Name      :  Hành động của tài nguyên
-- Meaning   :  Hành động trên tài nguyên nào
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [ResourceAction]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[resource_id] INT FOREIGN KEY REFERENCES [Resource]([id]) NOT NULL,
	[action_id] INT FOREIGN KEY REFERENCES [Action]([id]) NOT NULL,
	[is_active] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[created_at] DATETIME NOT NULL DEFAULT(GETDATE()),
	[create_by] INT,
	[updated_at] DATETIME NOT NULL DEFAULT(GETDATE()),
)
GO