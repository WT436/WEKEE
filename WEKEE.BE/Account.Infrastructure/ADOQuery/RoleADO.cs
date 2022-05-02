using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
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
    public class RoleADO
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                       new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<List<RoleSummaryReadDto>> GetSummary(SearchTextInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT R.[id] AS 'Id',R.[name] AS 'Name' FROM dbo.[Role] AS R WHERE R.[isActive] = 1 AND  R.[name] LIKE N'%{input.Text}%'");
            return await unitOfWork.FromSqlAsync<RoleSummaryReadDto>(query.ToString());
        }
        public async Task<List<RoleReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                                                                                     ");
            query.AppendLine("	   R.[id] AS 'Id'                                                                             ");
            query.AppendLine("	  ,R.[CreateBy] AS 'CreateBy'                                                                 ");
            query.AppendLine("	  ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'    ");
            query.AppendLine("	  ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                         ");
            query.AppendLine("	  ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                         ");
            query.AppendLine("	  ,R.[Name] AS 'Name'                                                                         ");
            query.AppendLine("	  ,R.[Description] AS 'Description'                                                           ");
            query.AppendLine("	  ,R.[LevelRole] AS 'LevelRole'                                                               ");
            query.AppendLine("	  ,R.[RoleManageId] AS 'RoleManageId'                                                         ");
            query.AppendLine("	  ,(SELECT RO.[name] FROM dbo.[Role] AS RO WHERE RO.id = R.[roleManageId]) AS 'RoleManageName'");
            query.AppendLine("	  ,R.[IsDelete] AS 'IsDelete'                                                                 ");
            query.AppendLine("	  ,R.[IsActive] AS 'IsActive'                                                                 ");
            query.AppendLine("FROM dbo.[Role] AS R                                                                            ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {RoleTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {RoleTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            query.AppendLine($"  ORDER BY  {RoleTransform.CONVERT_SQL(input.PropertyOrder)} {OrderByTransform.CONVERT_SQL(input.ValueOrderBy)}");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return await unitOfWork.FromSqlAsync<RoleReadDto>(query.ToString());
        }
        public async Task<List<NumberCountPageList>> GetCountForGetAllPageLst(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                  ");
            query.AppendLine("	  Count(*) AS 'TotalCount' ");
            query.AppendLine("FROM dbo.[Role] AS R");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {RoleTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {RoleTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            return await unitOfWork.FromSqlAsync<NumberCountPageList>(query.ToString());
        }
        public async Task<List<Role>> GetRolesById(List<int> ids)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT      *            ");
            query.AppendLine("FROM dbo.[Role] AS R ");
            query.AppendLine($" WHERE R.[Id] IN {JsonConvert.SerializeObject(ids).Replace("[", "(").Replace("]", ")")}");

            return await unitOfWork.FromSqlAsync<Role>(query.ToString());
        }
        public async Task<List<PermissionAssignment>> GetPermissionAssignment(int idRole)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT *  FROM dbo.[PermissionAssignment] AS R WHERE R.[roleId] =  {idRole}");
            return await unitOfWork.FromSqlAsync<PermissionAssignment>(query.ToString());
        }

    }
}
