using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ADOQuery
{
    public class PermissionADO
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                        new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<List<PermissionReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                                                                                                ");
            query.AppendLine("  R.[id] AS 'Id'                                                                                      ");
            query.AppendLine(" ,R.[name] AS 'Name'                                                                                  ");
            query.AppendLine(" ,R.[description] AS 'Description'                                                                    ");
            query.AppendLine(" ,R.[AtomicId] AS 'AtomicId'                                                                          ");
            query.AppendLine(" ,(SELECT A.[name] FROM dbo.[Atomic] AS A WHERE A.[id] = R.[AtomicId])  AS  'AtomicName'              ");
            query.AppendLine(" ,R.[levelPermition] AS 'LevelPermition'                                                              ");
            query.AppendLine(" ,R.[permissionId] AS 'PermissionId'                                                                  ");
            query.AppendLine(" ,(SELECT A.[name] FROM dbo.[Permission] AS A WHERE A.[id] = R.[permissionId]) AS 'PermissionName'    ");
            query.AppendLine(" ,R.[CreateBy] AS 'CreateBy'                                                                          ");
            query.AppendLine(" ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'             ");
            query.AppendLine(" ,R.[isActive] AS 'IsActive'                                                                          ");
            query.AppendLine(" ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                                  ");
            query.AppendLine(" ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                                  ");
            query.AppendLine("FROM dbo.[Permission] AS R                                                                            ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {PermissionTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {PermissionTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            query.AppendLine($"  ORDER BY  {PermissionTransform.CONVERT_SQL(input.PropertyOrder)} {OrderByTransform.CONVERT_SQL(input.ValueOrderBy)}");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return await unitOfWork.FromSqlAsync<PermissionReadDto>(query.ToString());
        }
        public async Task<List<NumberCountPageList>> GetCountForGetAllPageLst(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                  ");
            query.AppendLine("	  Count(*) AS 'TotalCount' ");
            query.AppendLine("FROM dbo.[Permission] AS R");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {PermissionTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {PermissionTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            return await unitOfWork.FromSqlAsync<NumberCountPageList>(query.ToString());
        }
        public async Task<List<Permission>> GetPermissionsById(List<int> ids)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT      *            ");
            query.AppendLine("FROM dbo.[Permission] AS R ");
            query.AppendLine($" WHERE R.[Id] IN {JsonConvert.SerializeObject(ids).Replace("[", "(").Replace("]", ")")}");

            return await unitOfWork.FromSqlAsync<Permission>(query.ToString());
        }
        public async Task<List<PermissionSummaryReadDto>> GetSummary(SearchTextInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT R.[id] AS 'Id',R.[name] AS 'Name'  FROM dbo.[Permission] AS R WHERE R.[name] LIKE N'%{input.Text}%' AND R.[isActive] = 1");
            return await unitOfWork.FromSqlAsync<PermissionSummaryReadDto>(query.ToString());
        }
        public async Task<List<ReourceAssignment>> GetReourceAssignment(int idPermission)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT *  FROM dbo.[ReourceAssignment] AS R WHERE R.[permissionId] = {idPermission}");
            return await unitOfWork.FromSqlAsync<ReourceAssignment>(query.ToString());
        }
        public async Task<List<PermissionFtReourceReadDto>> GetAllPermissionFtReource(int idPermission)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT R.[id]     AS 'Id'                                                                          ");
            query.AppendLine("      ,R.[resourceId] AS 'ResourceId'                                                              ");
            query.AppendLine("	  ,(SELECT RE.[name] FROM dbo.[Resource] AS RE WHERE RE.id = R.resourceId) AS 'ResourceName'     ");
            query.AppendLine("      ,R.[permissionId] AS 'PermissionId'                                                          ");
            query.AppendLine("	  ,(SELECT P.[name] FROM dbo.[Permission] AS P WHERE P.id = R.permissionId) AS 'PermissionName'  ");
            query.AppendLine("      ,R.[isActive] AS 'IsActive'                                                                  ");
            query.AppendLine("      ,R.[CreateBy] AS 'CreateBy'                                                                  ");
            query.AppendLine("      ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateName'       ");
            query.AppendLine("      ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                          ");
            query.AppendLine("      ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                          ");
            query.AppendLine("FROM [dbo].[ReourceAssignment] AS R                                                                ");
            query.AppendLine($"WHERE R.[permissionId] = {idPermission}                                                  ");
            return await unitOfWork.FromSqlAsync<PermissionFtReourceReadDto>(query.ToString());
        }
        public async Task<List<PermissionAssignment>> GetAllPrmissionByIdRole(int idRole)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT PA.[id]                               ");
            query.AppendLine("      ,PA.[roleId]                           ");
            query.AppendLine("      ,PA.[permissionId]                     ");
            query.AppendLine("      ,PA.[isActive]                         ");
            query.AppendLine("      ,PA.[CreateBy]                         ");
            query.AppendLine("      ,PA.[CreatedOnUtc]                     ");
            query.AppendLine("      ,PA.[UpdatedOnUtc]                     ");
            query.AppendLine("FROM [dbo].[PermissionAssignment] AS PA      ");
            query.AppendLine($"WHERE PA.[roleId] = {idRole}                ");
            return await unitOfWork.FromSqlAsync<PermissionAssignment>(query.ToString());
        }
        public async Task<List<UserGetPermission>> GetPermissionByUserName(string userName)
        {
            StringBuilder query = new StringBuilder();                                                                                
           
            query.AppendLine($"SELECT A.[name] AS 'Atomic', RE.[name] AS 'Resource', RE.typesRsc AS 'Type'                       ");
            query.AppendLine($"FROM dbo.[UserProfile] UP                                                                         ");
            query.AppendLine($"INNER JOIN dbo.[Subject] AS S ON UP.id =  S.userId                                                ");
            query.AppendLine($"INNER JOIN dbo.[SubjectAssignment] AS SA ON S.id = SA.subjectId                                   ");
            query.AppendLine($"INNER JOIN dbo.[Role] AS R ON SA.roleId =  R.id                                                   ");
            query.AppendLine($"INNER JOIN dbo.[PermissionAssignment] AS PA ON PA.roleId = R.id                                   ");
            query.AppendLine($"INNER JOIN dbo.[Permission] AS P ON PA.permissionId = P.id                                        ");
            query.AppendLine($"INNER JOIN dbo.[Atomic] AS A ON P.AtomicId =  A.id                                                ");
            query.AppendLine($"INNER JOIN dbo.[ReourceAssignment] AS RA ON RA.permissionId = P.id                                ");
            query.AppendLine($"INNER JOIN dbo.[Resource] AS RE ON RE.id = RA.resourceId                                          ");
            query.AppendLine($"WHERE UP.[userName] LIKE '{userName}' AND UP.isActive = 1 AND SA.isActive = 1 AND S.isActive = 1  ");
            query.AppendLine($"AND SA.isActive = 1 AND R.isActive = 1 AND PA.isActive = 1 AND P.isActive = 1 AND A.isActive = 1  ");
            query.AppendLine($"AND RA.isActive = 1 AND RE.isActive = 1                                                           ");
            
            return await unitOfWork.FromSqlAsync<UserGetPermission>(query.ToString());
        }
    }
}
