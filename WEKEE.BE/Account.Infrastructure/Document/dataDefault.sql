-- Resource 
USE Authorization
GO
SET IDENTITY_INSERT [Resource] ON
GO
DECLARE @cnt INT = 0;
WHILE @cnt < 10
BEGIN
 INSERT INTO [resource] ([id],[name],[types_rsc],[is_active],[description],[create_by])
		VALUES (@cnt,CONCAT('/Test-',@cnt), 'URL',@cnt%2, CONCAT(N'Trang chủ ',@cnt),@cnt%2)
 SET @cnt = @cnt + 1;
END;
GO
SET IDENTITY_INSERT [Resource] OFF
PRINT 'Ket thuc mo phong vong lap FOR cua Quantrimang.com';
GO