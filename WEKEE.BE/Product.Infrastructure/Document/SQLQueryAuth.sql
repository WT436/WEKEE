GO
----------------------------------------------------------------------------------
-- CREATOR     :  Trần Hải Nam
-- NAME        : 
-- DATE CREATE :
-- DESCRIPTION :
----------------------------------------------------------------------------------
GO
SELECT 
[User_Account].user_profile_id , 
[User_Account].user_name,
[User_Account].email,
[User_Account].is_online,
[User_Account].number_Phone ,
[Role].id,[Role].name,
[Role].role_id,
[Role].description,
[Role].level_role,
[Permission].id,
[Permission].name,
[Action].id,
[Action].name,
[Resource].[id],
[Resource].name,
[Resource].types_Rsc,
[Resource].description,
[Atomic].id,
[Atomic].name
FROM [User_Profile]
INNER JOIN [User_Account] ON [User_Profile].id = [User_Account].user_profile_id
INNER JOIN [Subject] ON [User_Account].user_profile_id = [Subject].user_account_id
INNER JOIN [SubjectAssignment] ON [SubjectAssignment].subject_id = [Subject].id
INNER JOIN [Role] ON [SubjectAssignment].role_id = [Role].id
INNER JOIN [PermissionAssignment] ON [ROLE].id = [PermissionAssignment].role_id
INNER JOIN [Permission] ON [Permission].id = [PermissionAssignment].permission_id
INNER JOIN [ActionAssignment] ON [ActionAssignment].permission_id = [Permission].id
INNER JOIN [Action] ON [ActionAssignment].action_id = [Action].id
INNER JOIN [ResourceAction] ON [ResourceAction].action_id = [Action].id
INNER JOIN [Resource] ON [ResourceAction].resource_id = [Resource].id
INNER JOIN [Atomic] ON [Action].atomic_id = [Atomic].id
WHERE [Role].id =1 AND [Role].is_active=1 
AND [PermissionAssignment].is_active=1 
AND [Permission].is_active=1 
AND [ActionAssignment].is_active=1
AND [Action].is_active =1
AND [ResourceAction].is_active =1
AND [Resource].is_active =1
AND [Atomic].is_active =1

GO
----------------------------------------------------------------------------------
--
--
--
--
----------------------------------------------------------------------------------
GO
SELECT 
	   [Role].id as 'Id',
	   [Role].description as 'Description',
	   [Role].level_role as 'LevelRole',
	   [Role].name as 'NameRole',
	   [Resource].description as 'DescriptionResource',
	   [Resource].name as 'NameResource', 
	   [Resource].types_Rsc as 'TypesRsc',
	   [Atomic].name as 'NameAtomic'
FROM [Role]
INNER JOIN [PermissionAssignment] ON [ROLE].id = [PermissionAssignment].role_id
INNER JOIN [Permission] ON [Permission].id = [PermissionAssignment].permission_id
INNER JOIN [ActionAssignment] ON [ActionAssignment].permission_id = [Permission].id
INNER JOIN [Action] ON [ActionAssignment].action_id = [Action].id
INNER JOIN [ResourceAction] ON [ResourceAction].action_id = [Action].id
INNER JOIN [Resource] ON [ResourceAction].resource_id = [Resource].id
INNER JOIN [Atomic] ON [Action].atomic_id = [Atomic].id
WHERE [Role].id =9

GO
----------------------------------------------------------------------------------
--
--
--
--
----------------------------------------------------------------------------------
GO
SELECT                                                                                
      [Role].id as 'Id',                                                              
      [Role].description as 'Description',                                            
      [Role].level_role as 'LevelRole',                                               
      [Role].name as 'NameRole',                                                      
      [Resource].description as 'DescriptionResource',                                
      [Resource].name as 'NameResource',                                              
      [Resource].types_Rsc as 'TypesRsc',                                             
      [Atomic].name as 'NameAtomic'                                                   
FROM [User_Account]                                                                   
INNER JOIN [Subject] ON [User_Account].user_profile_id = [Subject].user_account_id    
INNER JOIN [SubjectAssignment] ON [Subject].id = [SubjectAssignment].subject_id       
INNER JOIN[ROLE] ON[Role].id = [SubjectAssignment].role_id                            
INNER JOIN[PermissionAssignment] ON[ROLE].id = [PermissionAssignment].role_id         
INNER JOIN[Permission] ON[Permission].id = [PermissionAssignment].permission_id       
INNER JOIN[ActionAssignment] ON[ActionAssignment].permission_id = [Permission].id     
INNER JOIN[Action] ON[ActionAssignment].action_id = [Action].id                       
INNER JOIN[ResourceAction] ON[ResourceAction].action_id = [Action].id                 
INNER JOIN[Resource] ON[ResourceAction].resource_id = [Resource].id                   
INNER JOIN[Atomic] ON[Action].atomic_id = [Atomic].id                                 
WHERE[User_Account].user_profile_id = 1                             

GO
----------------------------------------------------------------------------------
-- CREATOR     :  Trần Hải Nam
-- DATE CREATE :  Wednesday, August 4, 2021
-- DESCRIPTION :  Lấy thông tin tai khoản cho admin
----------------------------------------------------------------------------------
SELECT 
[User_Profile].[id] AS 'Id',
[Infomation_User].[picture],
[User_Account].[user_name],
[User_Profile].[full_name],
[User_Account].[email],
[User_Account].[number_Phone],
[Infomation_User].[gender],
[User_Account].[is_status],
[ROLE].name
FROM [User_Account] 
LEFT JOIN [User_Profile] ON [User_Account].user_profile_id = [User_Profile].id
LEFT JOIN [Infomation_User] ON [User_Account].user_profile_id = [Infomation_User].user_account_id
LEFT JOIN  [Subject] ON [User_Account].user_profile_id  = [Subject].user_account_id
LEFT JOIN  [SubjectAssignment] ON [Subject].id = [SubjectAssignment].subject_id 
LEFT JOIN  [ROLE] ON[Role].id = [SubjectAssignment].role_id
WHERE 
--WHERE [User_Account].[is_status] = 6
--WHERE [Infomation_User].[gender] = N'KHÁC'
--WHERE [User_Account].[number_Phone] LIKE N'%11%'
--WHERE [User_Account].[email] LIKE N'%11%'
--WHERE [User_Profile].[full_name] LIKE N'%NAM%'
--WHERE [User_Account].[user_name] LIKE N'%NAM%'
--WHERE [User_Profile].[id] = '3'
ORDER BY id OFFSET 0 ROWS FETCH NEXT 15 ROWS ONLY           
----------------------------------------------------------------------------------
-- CREATOR     :  Trần Hải Nam
-- DATE CREATE :  Wednesday, August 4, 2021
-- DESCRIPTION :  Lấy thông tin quyền tài khoản
----------------------------------------------------------------------------------
SELECT * FROM Role
INNER JOIN SubjectAssignment ON Role.id = SubjectAssignment.role_id