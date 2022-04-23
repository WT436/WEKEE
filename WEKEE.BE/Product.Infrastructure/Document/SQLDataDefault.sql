GO
USE [Authorization]
GO
SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] ([id] 
	)
	   VALUES (1)
GO
SET IDENTITY_INSERT [UserProfile] OFF
GO
INSERT INTO [UserLogin] ([id],
						 [user_name],
						 [login_fall_number],
						 [email],
						 [number_Phone],
						 [password],
						 [password_salt],
						 [password_hash_algorithm],
						 [is_status])
	   VALUES (1,
			  'NamAdmin',
			  0,
			  'wt436.developer@gmail.com',
			  '0392516308',
			  'C0B6C08920B500EA9D5F02E99DB0D348',
			  'eutwsJWW6o',
			  'MD5',
			  1)
GO

--GO
--SET IDENTITY_INSERT [UserAccountIp] ON
--GO
--INSERT INTO [UserAccountIp] ([id],
--							 [ipv4],
--							 [user_agent],
--							 [account_id])
--	   VALUES (1,
--			  '1.54.195.166',
--			  'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36',
--			  1)
--SET IDENTITY_INSERT [UserAccountIp] OFF
--GO
--SET IDENTITY_INSERT [Address] ON
--GO
--INSERT INTO [Address] ([id],
--					   [adress_line_1],
--					   [adress_line_2],
--					   [adress_line_3],
--					   [description],
--					   [account_id])
--	   VALUES (1,
--	           N'Tu hoàng Nhổn',
--			   N'Tu hoàng Nhổn',
--			   N'Tu hoàng Nhổn',
--			   N'',
--			   1)
--SET IDENTITY_INSERT [Address] OFF
--GO
--SET IDENTITY_INSERT [InfomationUser] ON
--GO
--INSERT INTO [InfomationUser] ([id],
--							  [picture],
--							  [gender],
--							  [description],
--							  [account_id])
--       VALUES (1,
--			  'album/avatar/Account-Nam(737)-014329-04082021-S120x120.jpg',
--			  N'Nam',
--			  N'',
--			  1)
--SET IDENTITY_INSERT [InfomationUser] OFF
--GO
--SET IDENTITY_INSERT [Subject] ON
--GO
--INSERT INTO [Subject] ([id],[user_id])VALUES (1,1)
--SET IDENTITY_INSERT [Subject] OFF
--GO
-- [Resource]
GO
SET IDENTITY_INSERT [Resource] ON
GO
DECLARE @cnt INT = 1;
WHILE @cnt < 10000
BEGIN
 INSERT INTO [resource] ([id],[name],[types_rsc],[is_active],[description],[create_by])
		VALUES (@cnt,CONCAT('/Test-',@cnt), 'URL',@cnt%2, CONCAT(N'Trang chủ ',@cnt),@cnt%2)
 SET @cnt = @cnt + 1;
END;
GO
SET IDENTITY_INSERT [Resource] OFF
PRINT 'Resource data Default end';
GO
-- [Atomic]
SET IDENTITY_INSERT [Atomic] ON
GO
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (1,'GET',N'URL',N'yêu cầu xem thông tin') -- yêu cầu xem thông tin
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (2,'LIST',N'URL',N'hiển danh sách hoặc thông tin chi tiết') -- hiển danh sách hoặc thông tin chi tiết
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (3,'WATCH',N'URL',N'chỉ cho phép xem và không chức năng sửa đổi') -- chỉ cho phép xem và không chức năng sửa đổi
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (4,'UPDATE',N'URL',N'chỉnh sửa thông tin nâng cao, như active ....') -- chỉnh sửa thông tin nâng cao, như active ....
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (5,'CREATE',N'URL',N'tạo bản ghi trên Database') -- tạo bản ghi trên db
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (6,'DELETE',N'URL',N'active hoặc xóa bản ghi trên Database') -- active hoặc xóa bản ghi trên db
INSERT INTO [Atomic] ([id],[name],[types_rsc],[description])VALUES (7,'EDIT',N'URL',N'chỉnh sửa thông tin căn bản') -- chỉnh sửa thông tin căn bản
GO
SET IDENTITY_INSERT [Atomic] OFF
PRINT '[Atomic] data Default end';
GO

-- [Action]
GO
SET IDENTITY_INSERT [Action] ON
GO
DECLARE @cnt INT = 1;
WHILE @cnt < 10
BEGIN
 INSERT INTO [Action] 
 (
	[id] ,
	[name],
	[atomic_id],
	[description],
	[is_active],
	[create_by]
 )
		VALUES 
		(
			@cnt,
			CONCAT('action-main-',@cnt),
			FLOOR(RAND()*(10-1)+1),
			CONCAT(N'Trang chủ ',@cnt),
			1,
			1
		)
 SET @cnt = @cnt + 1;
END;

WHILE @cnt < 1000
BEGIN
 INSERT INTO [Action] 
 (
	[id] ,
	[name],
	[atomic_id],
	[description],
	[action_base],
	[is_active],
	[create_by]
 )
		VALUES 
		(
			@cnt,
			CONCAT('action-',@cnt),
			FLOOR(RAND()*(10-1)+1),
			CONCAT(N'Trang chủ ',@cnt),
			FLOOR(RAND()*(10-1)+1),
			@cnt%2,
			1
		)
 SET @cnt = @cnt + 1;
END;

GO
SET IDENTITY_INSERT [Action] OFF
PRINT '[Action] data Default end';
GO

-- [Permission]
SET IDENTITY_INSERT [Permission] ON
GO
DECLARE @cnt INT = 1;
WHILE @cnt < 1000
BEGIN
	INSERT 
		INTO [Permission] 
		(
			[id],
			[name],
			[description],
			[is_active],
			[create_by]
		)
		VALUES 
		(
			@cnt,
			CONCAT('Permission-',@cnt),
			CONCAT(N'Trang chủ ',@cnt),
			@cnt%2,
			1
		)
	SET @cnt = @cnt + 1;
END;

GO
SET IDENTITY_INSERT [Permission] OFF
PRINT '[Permission] data Default end';
GO

-- [Role]
SET IDENTITY_INSERT [Role] ON
GO
Delete [Role]
DECLARE @cnt INT = 1;
WHILE @cnt < 10
BEGIN
 INSERT INTO [Role] 
 (
	[id],
	[name],
	[description],
	[level_role],
	[role_id],
	[is_delete],
	[is_active],
	[create_by]
 )
		VALUES 
		(
			@cnt,
			CONCAT('Role-main-',@cnt),
			CONCAT(N'Trang chủ ',@cnt),
			0,
			@cnt,
			FLOOR(RAND()*(1-0+1)+1),
			FLOOR(RAND()*(1-0+1)+1),
			1
		)
 SET @cnt = @cnt + 1;
END;

WHILE @cnt < 1000
BEGIN
 INSERT INTO [Role] 
 (
	[id],
	[name],
	[description],
	[level_role],
	[role_id],
	[is_delete],
	[is_active],
	[create_by]
 )
		VALUES 
		(
			@cnt,
			CONCAT('Role-main-',@cnt),
			CONCAT(N'Trang chủ ',@cnt),
			FLOOR(RAND()*(6-1)+1),
			FLOOR(RAND()*(10-1)+1),
			FLOOR(RAND()*(1-0+1)),
			FLOOR(RAND()*(1-0+1)),
			1
		)
 SET @cnt = @cnt + 1;
END;

GO
SET IDENTITY_INSERT [Role] OFF
PRINT '[Role] data Default end';
GO
--
SET IDENTITY_INSERT [UserProfile] ON
GO
INSERT INTO [UserProfile] ([id],[is_accept_term]) VALUES (1,1)
SET IDENTITY_INSERT [UserProfile] OFF

GO
SET IDENTITY_INSERT [UserAccountStatus] ON
GO
INSERT INTO [UserAccountStatus] ([id],[account_id],[status_id])VALUES (1,1,0)
SET IDENTITY_INSERT [UserAccountStatus] OFF
GO
