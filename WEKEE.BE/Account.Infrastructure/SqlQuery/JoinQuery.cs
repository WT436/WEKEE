using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.SqlQuery
{
    public class JoinQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());
        public List<RoleAuthDtos> RoleAnonimuosDtos()
        {
            StringBuilder query = new StringBuilder();

            //query.AppendLine("     SELECT                                                                                  ");
            //query.AppendLine("           [Role].id as 'Id',                                                                ");
            //query.AppendLine("           [Role].description as 'Description',                                              ");
            //query.AppendLine("           [Role].level_role as 'LevelRole',                                                 ");
            //query.AppendLine("           [Role].name as 'NameRole',                                                        ");
            //query.AppendLine("           [Resource].description as 'DescriptionResource',                                  ");
            //query.AppendLine("           [Resource].name as 'NameResource',                                                ");
            //query.AppendLine("           [Resource].types_Rsc as 'TypesRsc',                                               ");
            //query.AppendLine("           [Atomic].name as 'NameAtomic'                                                     ");
            //query.AppendLine("     FROM [Role]                                                                             ");
            //query.AppendLine("     INNER JOIN [PermissionAssignment] ON [ROLE].id = [PermissionAssignment].role_id         ");
            //query.AppendLine("     INNER JOIN [Permission] ON [Permission].id = [PermissionAssignment].permission_id       ");
            //query.AppendLine("     INNER JOIN [ActionAssignment] ON [ActionAssignment].permission_id = [Permission].id     ");
            //query.AppendLine("     INNER JOIN [Action] ON [ActionAssignment].action_id = [Action].id                       ");
            //query.AppendLine("     INNER JOIN [ResourceAction] ON [ResourceAction].action_id = [Action].id                 ");
            //query.AppendLine("     INNER JOIN [Resource] ON [ResourceAction].resource_id = [Resource].id                   ");
            //query.AppendLine("     INNER JOIN [Atomic] ON [Action].atomic_id = [Atomic].id                                 ");
            //query.AppendLine("     WHERE [Role].id =9                                                                      ");

            string sql = @"
                            SELECT                                                                                 
                                  [Role].id as 'Id',                                                               
                                  [Role].description as 'Description',                                             
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
                         ";
            return unitOfWork.FromSql<RoleAuthDtos>(query.ToString());
        }

        public List<RoleAuthDtos> RoleAccount(int id_user_account)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("     SELECT                                                                                  ");
            query.AppendLine("           [Role].id as 'Id',                                                                ");
            query.AppendLine("           [Role].level_role as 'LevelRole',                                                 ");
            query.AppendLine("           [Role].name as 'NameRole',                                                        ");
            query.AppendLine("           [Resource].name as 'NameResource',                                                ");
            query.AppendLine("           [Resource].types_Rsc as 'TypesRsc',                                               ");
            query.AppendLine("           [Atomic].name as 'NameAtomic'                                                     ");
            query.AppendLine("     FROM [User_Account]                                                                     ");
            query.AppendLine("     INNER JOIN [Subject] ON [User_Account].user_profile_id = [Subject].user_account_id      ");
            query.AppendLine("     INNER JOIN [SubjectAssignment] ON [Subject].id = [SubjectAssignment].subject_id         ");
            query.AppendLine("     INNER JOIN[ROLE] ON[Role].id = [SubjectAssignment].role_id                              ");
            query.AppendLine("     INNER JOIN[PermissionAssignment] ON[ROLE].id = [PermissionAssignment].role_id           ");
            query.AppendLine("     INNER JOIN[Permission] ON[Permission].id = [PermissionAssignment].permission_id         ");
            query.AppendLine("     INNER JOIN[ActionAssignment] ON[ActionAssignment].permission_id = [Permission].id       ");
            query.AppendLine("     INNER JOIN[Action] ON[ActionAssignment].action_id = [Action].id                         ");
            query.AppendLine("     INNER JOIN[ResourceAction] ON[ResourceAction].action_id = [Action].id                   ");
            query.AppendLine("     INNER JOIN[Resource] ON[ResourceAction].resource_id = [Resource].id                     ");
            query.AppendLine("     INNER JOIN[Atomic] ON[Action].atomic_id = [Atomic].id                                   ");
            query.AppendLine($"    WHERE[User_Account].user_profile_id = {id_user_account}                                 ");
            return unitOfWork.FromSql<RoleAuthDtos>(query.ToString());
        }

        public List<RoleAuthDtos> RoleAccountFull(int id_user_account)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("     SELECT                                                                                  ");
            query.AppendLine("           [Role].id as 'Id',                                                                ");
            query.AppendLine("           [Role].description as 'Description',                                              ");
            query.AppendLine("           [Role].level_role as 'LevelRole',                                                 ");
            query.AppendLine("           [Role].name as 'NameRole',                                                        ");
            query.AppendLine("           [Resource].description as 'DescriptionResource',                                  ");
            query.AppendLine("           [Resource].name as 'NameResource',                                                ");
            query.AppendLine("           [Resource].types_Rsc as 'TypesRsc',                                               ");
            query.AppendLine("           [Atomic].name as 'NameAtomic'                                                     ");
            query.AppendLine("     FROM [User_Account]                                                                     ");
            query.AppendLine("     INNER JOIN [Subject] ON [User_Account].user_profile_id = [Subject].user_account_id      ");
            query.AppendLine("     INNER JOIN [SubjectAssignment] ON [Subject].id = [SubjectAssignment].subject_id         ");
            query.AppendLine("     INNER JOIN[ROLE] ON[Role].id = [SubjectAssignment].role_id                              ");
            query.AppendLine("     INNER JOIN[PermissionAssignment] ON[ROLE].id = [PermissionAssignment].role_id           ");
            query.AppendLine("     INNER JOIN[Permission] ON[Permission].id = [PermissionAssignment].permission_id         ");
            query.AppendLine("     INNER JOIN[ActionAssignment] ON[ActionAssignment].permission_id = [Permission].id       ");
            query.AppendLine("     INNER JOIN[Action] ON[ActionAssignment].action_id = [Action].id                         ");
            query.AppendLine("     INNER JOIN[ResourceAction] ON[ResourceAction].action_id = [Action].id                   ");
            query.AppendLine("     INNER JOIN[Resource] ON[ResourceAction].resource_id = [Resource].id                     ");
            query.AppendLine("     INNER JOIN[Atomic] ON[Action].atomic_id = [Atomic].id                                   ");
            query.AppendLine($"    WHERE[User_Account].user_profile_id = {id_user_account}                                 ");
            return unitOfWork.FromSql<RoleAuthDtos>(query.ToString());
        }

        public async Task<List<AccountShowDtos>> GetAccountAdmin(int pageBegin, int pageSize,
                                                     string property, string orderBy,
                                                     string propertySearch, string valuesSearch)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("      SELECT                                                                                            ");
            query.AppendLine("              [User_Profile].[id]                 AS 'Id',                                              ");
            query.AppendLine("              [Infomation_User].[picture]         AS 'Picture',                                         ");
            query.AppendLine("              [User_Account].[user_name]          AS 'UserName',                                        ");
            query.AppendLine("              [User_Profile].[full_name]          AS 'FullName',                                        ");
            query.AppendLine("              [User_Account].[email]              AS 'Email',                                           ");
            query.AppendLine("              [User_Account].[number_Phone]       AS 'NumberPhone',                                     ");
            query.AppendLine("              [Infomation_User].[gender]          AS 'Gender',                                          ");
            query.AppendLine("              [User_Account].[is_status]          AS 'IsStattus',                                       ");
            query.AppendLine("              [ROLE].[name]                       AS 'Role'                                             ");
            query.AppendLine("      FROM  [User_Account]                                                                              ");
            query.AppendLine("      LEFT JOIN[User_Profile] ON[User_Account].user_profile_id = [User_Profile].id                      ");
            query.AppendLine("      LEFT JOIN[Infomation_User] ON[User_Account].user_profile_id = [Infomation_User].user_account_id   ");
            query.AppendLine("      LEFT  JOIN[Subject] ON[User_Account].user_profile_id = [Subject].user_account_id                  ");
            query.AppendLine("      LEFT  JOIN[SubjectAssignment] ON[Subject].id = [SubjectAssignment].subject_id                     ");
            query.AppendLine("      AND [SubjectAssignment].is_active = 1                                                             ");
            query.AppendLine("      LEFT  JOIN[ROLE] ON[Role].id = [SubjectAssignment].role_id                                        ");
            if (string.IsNullOrEmpty(propertySearch))
            {
            }
            if (propertySearch.Equals("User_Profile_Id"))
            {
                query.AppendLine($" WHERE [User_Profile].[id] ={valuesSearch}                                                         ");
            }
            if (propertySearch.Equals("User_Profile_User_Name"))
            {
                query.AppendLine($" WHERE [User_Account].[user_name] LIKE N'%{valuesSearch}%'                                         ");
            }
            if (propertySearch.Equals("User_Profile_Full_Name"))
            {
                query.AppendLine($" WHERE [User_Profile].[full_name] LIKE N'%{valuesSearch}%'                                         ");
            }
            if (propertySearch.Equals("User_Profile_Email"))
            {
                query.AppendLine($" WHERE [User_Account].[email] LIKE N'%{valuesSearch}%'                                             ");
            }
            if (propertySearch.Equals("User_Profile_Number_Phone"))
            {
                query.AppendLine($" WHERE [User_Account].[number_Phone] LIKE N'%{valuesSearch}%'                                      ");
            }
            if (propertySearch.Equals("User_Profile_Gender")
                && (valuesSearch.Equals("Nam")
                    || valuesSearch.Equals("Nữ")
                    || valuesSearch.Equals("Khác")))
            {
                query.AppendLine($" WHERE [Infomation_User].[gender] = N'{valuesSearch}'                                              ");
            }
            if (propertySearch.Equals("User_Profile_Is_Status"))
            {
                query.AppendLine($" WHERE [User_Account].[is_status] = {valuesSearch}                                                 ");
            }
            query.AppendLine($"     ORDER BY id OFFSET {pageBegin} ROWS FETCH NEXT {pageSize} ROWS ONLY                               ");

            return await unitOfWork.FromSqlAsync<AccountShowDtos>(query.ToString());
        }
    }
}
