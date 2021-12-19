-- Resource 
USE [Authorization]
GO
--SET IDENTITY_INSERT [Resource] ON
--GO
--DECLARE @cnt INT = 0;
--WHILE @cnt < 10000
--BEGIN
-- INSERT INTO [resource] ([id],[name],[types_rsc],[is_active],[description],[create_by])
--		VALUES (@cnt,CONCAT('/Test-',@cnt), 'URL',@cnt%2, CONCAT(N'Trang chủ ',@cnt),@cnt%2)
-- SET @cnt = @cnt + 1;
--END;
--GO
--SET IDENTITY_INSERT [Resource] OFF
--PRINT 'Resource data Default end';
--GO

--SET IDENTITY_INSERT [Action] ON
--GO
--DECLARE @cnt INT = 0;
--WHILE @cnt < 10
--BEGIN
-- INSERT INTO [Action] 
-- (
--	[id] ,
--	[name],
--	[atomic_id],
--	[description],
--	[is_active],
--	[create_by]
-- )
--		VALUES 
--		(
--			@cnt,
--			CONCAT('action-main-',@cnt),
--			FLOOR(RAND()*(10-1)+1),
--			CONCAT(N'Trang chủ ',@cnt),
--			1,
--			1
--		)
-- SET @cnt = @cnt + 1;
--END;

--WHILE @cnt < 1000
--BEGIN
-- INSERT INTO [Action] 
-- (
--	[id] ,
--	[name],
--	[atomic_id],
--	[description],
--	[action_base],
--	[is_active],
--	[create_by]
-- )
--		VALUES 
--		(
--			@cnt,
--			CONCAT('action-',@cnt),
--			FLOOR(RAND()*(10-1)+1),
--			CONCAT(N'Trang chủ ',@cnt),
--			FLOOR(RAND()*(10-1)+1),
--			@cnt%2,
--			1
--		)
-- SET @cnt = @cnt + 1;
--END;

--GO
--SET IDENTITY_INSERT [Action] OFF
--PRINT '[Action] data Default end';
--GO

--SET IDENTITY_INSERT [Permission] ON
--GO
--DECLARE @cnt INT = 0;
--WHILE @cnt < 1000
--BEGIN
--	INSERT 
--		INTO [Permission] 
--		(
--			[id],
--			[name],
--			[description],
--			[is_active],
--			[create_by]
--		)
--		VALUES 
--		(
--			@cnt,
--			CONCAT('Permission-',@cnt),
--			CONCAT(N'Trang chủ ',@cnt),
--			@cnt%2,
--			1
--		)
--	SET @cnt = @cnt + 1;
--END;

--GO
--SET IDENTITY_INSERT [Permission] OFF
--PRINT '[Permission] data Default end';
--GO


SET IDENTITY_INSERT [Role] ON
GO
Delete [Role]
DECLARE @cnt INT = 0;
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
			FLOOR(RAND()*(2-1)),
			FLOOR(RAND()*(2-1)),
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
			FLOOR(RAND()*(2-1)),
			FLOOR(RAND()*(2-1)),
			1
		)
 SET @cnt = @cnt + 1;
END;

GO
SET IDENTITY_INSERT [Role] OFF
PRINT '[Role] data Default end';
GO