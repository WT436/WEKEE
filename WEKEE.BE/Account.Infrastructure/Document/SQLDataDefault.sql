GO
USE [Authorization]
GO

-- tất cả đường dẫn mà server tạo ra
SET IDENTITY_INSERT [Resource] ON
GO

INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (1,'/', 'URL', N'Trang Chủ')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (2,'/registration', 'URL', N'Đăng ký tài khoản')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (3,'/log-in', 'URL', N'Đăng Nhập')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (4,'/forgot-password', 'URL', N'Quên Mật Khẩu')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (5,'/change-password', 'URL', N'Đổi Mật Khẩu')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (6,'/confirm-password', 'URL', N'Xác Nhận')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (7,'/restore-password', 'URL', N'Khôi phục mật khẩu')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (8,'/log-in-Auth-v2', 'URL', N'Đăng nhập bên thứ 3')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (9,'/log-out', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (10,'/resource-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (11,'/atomic-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (12,'/action-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (13,'/action-assignment-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (14,'/algorithm-role-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (15,'/constraint-assignment-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (16,'/permission-assignment-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (17,'/permission-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (18,'/resource-action-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (19,'/role-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (20,'/subject-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (21,'/subject-assignment-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (22,'/subject-group-basic', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (23,'/admin-home', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (24,'/admin-role', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (25,'/admin-process-account', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (26,'/admin-upload-image-account', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (27,'/admin-account', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (28,'/admin-account-process-list', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (29,'/remove-image', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (30,'/upload-avatar', 'URL', N'Đăng xuất')
INSERT INTO [Resource] ([id],[name],[types_Rsc],[description])VALUES (31,'/name-avatar-default', 'URL', N'Đăng xuất')
GO
SET IDENTITY_INSERT [Resource] OFF
GO
-- các hành động trên đường dẫn đó
SET IDENTITY_INSERT [Atomic] ON
GO
INSERT INTO [Atomic] ([id],[name],[description])VALUES (1,'GET',N'yêu cầu xem thông tin') -- yêu cầu xem thông tin
INSERT INTO [Atomic] ([id],[name],[description])VALUES (2,'LIST',N'hiển danh sách hoặc thông tin chi tiết') -- hiển danh sách hoặc thông tin chi tiết
INSERT INTO [Atomic] ([id],[name],[description])VALUES (3,'WATCH',N'chỉ cho phép xem và không chức năng sửa đổi') -- chỉ cho phép xem và không chức năng sửa đổi
INSERT INTO [Atomic] ([id],[name],[description])VALUES (4,'UPDATE',N'chỉnh sửa thông tin nâng cao, như active ....') -- chỉnh sửa thông tin nâng cao, như active ....
INSERT INTO [Atomic] ([id],[name],[description])VALUES (5,'CREATE',N'tạo bản ghi trên Database') -- tạo bản ghi trên db
INSERT INTO [Atomic] ([id],[name],[description])VALUES (6,'DELETE',N'active hoặc xóa bản ghi trên Database') -- active hoặc xóa bản ghi trên db
INSERT INTO [Atomic] ([id],[name],[description])VALUES (7,'EDIT',N'chỉnh sửa thông tin căn bản') -- chỉnh sửa thông tin căn bản
GO
SET IDENTITY_INSERT [Atomic] OFF
GO

SET IDENTITY_INSERT [Permission] ON
GO
INSERT INTO [Permission] ([id],[name],[description])VALUES (1,'GET ALL',N'yêu cầu xem tất cả thông tin') -- yêu cầu xem thông tin
INSERT INTO [Permission] ([id],[name],[description])VALUES (2,'LIST ALL',N'hiển thị tất cả danh sách hoặc thông tin chi tiết') -- hiển danh sách hoặc thông tin chi tiết
INSERT INTO [Permission] ([id],[name],[description])VALUES (3,'WATCH ALL',N'chỉ cho phép xem tất cả và không chức năng sửa đổi') -- chỉ cho phép xem và không chức năng sửa đổi
INSERT INTO [Permission] ([id],[name],[description])VALUES (4,'UPDATE ALL',N'chỉnh sửa tất cả thông tin nâng cao, như active ....') -- chỉnh sửa thông tin nâng cao, như active ....
INSERT INTO [Permission] ([id],[name],[description])VALUES (5,'CREATE ALL',N'tạo bản ghi tất cả trên Database') -- tạo bản ghi trên db
INSERT INTO [Permission] ([id],[name],[description])VALUES (6,'DELETE ALL',N'active hoặc xóa tất cả bản ghi trên Database') -- active hoặc xóa bản ghi trên db
INSERT INTO [Permission] ([id],[name],[description])VALUES (7,'EDIT ALL',N'chỉnh sửa tất cả thông tin căn bản') -- chỉnh sửa thông tin căn bản
SET IDENTITY_INSERT [Permission] OFF
GO

SET IDENTITY_INSERT [Role] ON
GO
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (1,'Admin',1,null,N'Nhóm người có quyền quyền quản trị toàn bộ hệ thống (cao nhất )')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (2,'Super',1,1,N'Quyền cho nhà cung cấp')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (3,'Administrator',1,1,N'Nhóm người dùng có quyền sử dụng toàn bộ các tính năng')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (4,'Editor',1,1,N'Nhóm này có quyền đăng bài viết lên website (publish) và quản lý các bài viết của những người dùng khác.')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (5,'Author',1,1,N'Nhóm này sẽ có quyền đăng bài lên website và quản lý các bài viết của họ.')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (6,'Contributor',1,1,N' Nhóm này sẽ có quyền viết bài mới nhưng không được phép đăng lên mà chỉ có thể gửi để xét duyệt và quản lý bài viết của họ.')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (7,'Subscriber',1,1,N'Người dùng trong nhóm này chỉ có thể quản lý thông tin cá nhân của họ.')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (8,'Super Anonymous',1,1,N'Người dùng vô danh. đã đặt hàng và được cấp tài khoản vô danh để nhận biết')
INSERT INTO [Role] ([id],[name],[level_role],[role_id],[description])VALUES (9,'Anonymous',1,1,N'Người dùng vô danh.')
GO
SET IDENTITY_INSERT [Role] OFF
GO

SET IDENTITY_INSERT [User_Profile] ON
GO
INSERT INTO [User_Profile] ([id],[first_name],[last_name],[full_name])VALUES (1,N'Trần Hữu',N'Hải Nam',N'Trần Hữu Hải Nam')
SET IDENTITY_INSERT [User_Profile] OFF
GO

SET IDENTITY_INSERT [User_Account_Status] ON
GO
INSERT INTO [User_Account_Status] ([id])VALUES (1)
SET IDENTITY_INSERT [User_Account_Status] OFF
GO

INSERT INTO [User_Account] ([user_profile_id],[user_name],[email],[number_Phone],[password],[password_salt],[password_hash_algorithm],[status_id])VALUES (1,'NamAdmin','wt436.developer@gmail.com','0392516308','C0B6C08920B500EA9D5F02E99DB0D348','eutwsJWW6o','MD5',1)
GO

SET IDENTITY_INSERT [User_Account_Ip] ON
GO
INSERT INTO [User_Account_Ip] ([id],[ip],[user-Agent],[ip_User_Account])VALUES (1,'1.54.195.166','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36',1)
SET IDENTITY_INSERT [User_Account_Ip] OFF

GO
SET IDENTITY_INSERT [Address] ON
GO
INSERT INTO [Address] ([id],[adress_line_1],[adress_line_2],[adress_line_3],[description],[user_account_id])VALUES (1,N'Tu hoàng Nhổn',N'Tu hoàng Nhổn',N'Tu hoàng Nhổn',N'',1)
SET IDENTITY_INSERT [Address] OFF

GO
SET IDENTITY_INSERT [Infomation_User] ON
GO
INSERT INTO [Infomation_User] ([id],[picture],[gender],[description],[user_account_id])VALUES (1,'album/avatar/Account-Nam(737)-014329-04082021-S120x120.jpg',N'Nam',N'',1)
SET IDENTITY_INSERT [Infomation_User] OFF
GO
SET IDENTITY_INSERT [Subject] ON
GO
INSERT INTO [Subject] ([id],[user_account_id])VALUES (1,1)
SET IDENTITY_INSERT [Subject] OFF

GO
SET IDENTITY_INSERT [Action] ON
GO
INSERT INTO [Action] ([id],[name],[atomic_id],[description])VALUES (1,N'',1)
SET IDENTITY_INSERT [Action] OFF