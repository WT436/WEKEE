using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
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
    public class SubjectADO
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                      new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<List<SubjectReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                                                                                      ");
            query.AppendLine("	  R.[id] AS 'Id'                                                                          ");
            query.AppendLine("	 ,R.[userId]  AS 'UserId'                                                                 ");
            query.AppendLine("	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[userId] )  AS 'UserName'     ");
            query.AppendLine("	 ,R.[gorupId] AS 'GorupId'                                                                ");
            query.AppendLine("	 ,(SELECT U.nameGroup FROM [Group] AS U WHERE U.id = R.[gorupId] ) AS 'GorupName'         ");
            query.AppendLine("	 ,R.[isActive] AS 'IsActive'                                                              ");
            query.AppendLine("	 ,R.[CreateBy] AS 'CreateBy'                                                              ");
            query.AppendLine("	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName' ");
            query.AppendLine("	 ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                      ");
            query.AppendLine("	 ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                      ");
            query.AppendLine("FROM dbo.[Subject] AS R");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {SubjectTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {SubjectTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            query.AppendLine($"  ORDER BY  {SubjectTransform.CONVERT_SQL(input.PropertyOrder)} {OrderByTransform.CONVERT_SQL(input.ValueOrderBy)}");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return await unitOfWork.FromSqlAsync<SubjectReadDto>(query.ToString());
        }
        public async Task<List<NumberCountPageList>> GetCountForGetAllPageLst(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                  ");
            query.AppendLine("	  Count(*) AS 'TotalCount' ");
            query.AppendLine("FROM dbo.[Subject] AS R");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {SubjectTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {SubjectTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            return await unitOfWork.FromSqlAsync<NumberCountPageList>(query.ToString());
        }
        public async Task<List<Subject>> GetSubjectsById(List<int> ids)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT      *            ");
            query.AppendLine("FROM dbo.[Subject] AS R ");
            query.AppendLine($" WHERE R.[Id] IN {JsonConvert.SerializeObject(ids).Replace("[", "(").Replace("]", ")")}");

            return await unitOfWork.FromSqlAsync<Subject>(query.ToString());
        }
        public async Task<List<SubjectAssignment>> GetSubjectAssignmentByIdSubject(int idSubject)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($" SELECT *  FROM dbo.[SubjectAssignment] AS R WHERE R.[subjectId] = {idSubject}");
            return await unitOfWork.FromSqlAsync<SubjectAssignment>(query.ToString());
        }
    }
}
