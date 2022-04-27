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
