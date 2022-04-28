USE [AuthorizationDB]
---------------------------------------------------------------------------------------------------
GO
SELECT                                                                                     
	  R.[id] AS 'Id'                                                                         
	 ,R.[name] AS 'Name'                                                                     
	 ,R.[typesRsc] AS 'TypesRsc'                                                             
	 ,R.[description] AS 'Description'                                                       
	 ,R.[isActive] AS 'IsActive'                                                             
	 ,R.[CreateBy] AS 'CreateBy'                                                             
	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'
	 ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                     
	 ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                     
FROM dbo.[Resource] AS R                                                                   
 WHERE R.[id] = 1
 AND R.[CreateBy]  = 1
 AND (CAST(R.[CreatedOnUtc] AS Date) =  '2022-04-25')
 AND (CAST(R.[UpdatedOnUtc] AS Date) =  '2022-04-25')
 AND R.[name]  LIKE N'%s%'
 AND R.[typesRsc] = '0'
 AND R.[description] LIKE N'%s%'
 AND R.[isActive] = 1
  ORDER BY  Id ASC
  OFFSET((1 - 1) * 1) ROWS                                                                        
  FETCH NEXT 1 ROWS ONLY    
GO
SELECT                                                                                     
	  COUNT(*) AS 'COUNT'                                                     
FROM dbo.[Resource] AS R                                                                   
 WHERE R.[id] = 1
 AND R.[CreateBy]  = 1
 AND (CAST(R.[CreatedOnUtc] AS Date) =  '2022-04-25')
 AND (CAST(R.[UpdatedOnUtc] AS Date) =  '2022-04-25')
 AND R.[name]  LIKE N'%s%'
 AND R.[typesRsc] = '0'
 AND R.[description] LIKE N'%s%'
 AND R.[isActive] = 1
---------------------------------------------------------------------------------------------------                                                                                                                                            
SELECT                                                                                     
	  R.[id] AS 'Id'                                                                         
	 ,R.[name] AS 'Name'                                                                     
	 ,R.[typesRsc] AS 'TypesRsc'                                                             
	 ,R.[description] AS 'Description'                                                       
	 ,R.[isActive] AS 'IsActive'                                                             
	 ,R.[CreateBy] AS 'CreateBy'                                                             
	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'
	 ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                     
	 ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                     
FROM dbo.[Resource] AS R                                                                   
  ORDER BY  Id DESC
  OFFSET((10 - 1) * 20) ROWS                                                                        
  FETCH NEXT 20 ROWS ONLY                                                                            
-----------------------------------------------------------------------------------------------------

SELECT                                                                                     
	  R.[id] AS 'Id'                                                                         
	 ,R.[name] AS 'Name'                                                                     
	 ,R.[description] AS 'Description'                                                             
	 ,R.[AtomicId] AS 'AtomicId'                                                       
	 ,(SELECT A.[name] FROM dbo.[Atomic] AS A WHERE A.[id] = R.[AtomicId])  AS  'AtomicName'
	 ,R.[levelPermition] AS 'LevelPermition'
	 ,R.[permissionId] AS 'PermissionId'
	 ,(SELECT A.[name] FROM dbo.[Permission] AS A WHERE A.[id] = R.[permissionId]) AS 'PermissionName'
	 ,R.[CreateBy] AS 'CreateBy'                                                             
	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'
	 ,R.[isActive] AS 'IsActive' 
	 ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                     
	 ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                     
FROM dbo.[Permission] AS R  

-------------------------------------------------------------------------------------------------------
SELECT R.[id] AS 'Id',R.[name] AS 'Name' ,R.[typesRsc] AS 'TypesRsc'  FROM dbo.[Atomic] AS R WHERE R.[isActive] = 1
-------------------------------------------------------------------------------------------------------
SELECT R.[id] AS 'Id',R.[name] AS 'Name'  FROM dbo.[Permission] AS R WHERE R.[name] LIKE N'%1%' AND R.[isActive] = 1

-------------------------------------------------------------------------------------------------------
SELECT                                                                                     
	   R.[id] AS 'Id'
	  ,R.[CreateBy] AS 'CreateBy'
	  ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'
	  ,R.[CreatedOnUtc] AS 'CreatedOnUtc'
	  ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'
	  ,R.[Name] AS 'Name'
	  ,R.[Description] AS 'Description'
	  ,R.[LevelRole] AS 'LevelRole'
	  ,R.[RoleManageId] AS 'RoleManageId'
	  ,(SELECT RO.[name] FROM dbo.[Role] AS RO WHERE RO.id = R.[roleManageId]) AS 'RoleManageName'
	  ,R.[IsDelete] AS 'IsDelete'
	  ,R.[IsActive] AS 'IsActive'
FROM dbo.[Role] AS R                                                                   
  ORDER BY  Id ASC
  OFFSET((1 - 1) * 20) ROWS                                                                        
  FETCH NEXT 20 ROWS ONLY   
---------------------------------------------------------------------------------------------------------