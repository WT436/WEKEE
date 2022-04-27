using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.AtomicDTO;
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
    public class AtomicADO
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                        new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<List<AtomicReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                                                                                     ");
            query.AppendLine("	  R.[id] AS 'Id'                                                                         ");
            query.AppendLine("	 ,R.[name] AS 'Name'                                                                     ");
            query.AppendLine("	 ,R.[typesRsc] AS 'TypesRsc'                                                             ");
            query.AppendLine("	 ,R.[description] AS 'Description'                                                       ");
            query.AppendLine("	 ,R.[isActive] AS 'IsActive'                                                             ");
            query.AppendLine("	 ,R.[CreateBy] AS 'CreateBy'                                                             ");
            query.AppendLine("	 ,(SELECT U.[userName] FROM UserProfile AS U WHERE U.id = R.[CreateBy]) AS 'CreateByName'");
            query.AppendLine("	 ,R.[CreatedOnUtc] AS 'CreatedOnUtc'                                                     ");
            query.AppendLine("	 ,R.[UpdatedOnUtc] AS 'UpdatedOnUtc'                                                     ");
            query.AppendLine("FROM dbo.[Atomic] AS R                                                                   ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {AtomicTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {AtomicTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            query.AppendLine($"  ORDER BY  {AtomicTransform.CONVERT_SQL(input.PropertyOrder)} {OrderByTransform.CONVERT_SQL(input.ValueOrderBy)}");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return await unitOfWork.FromSqlAsync<AtomicReadDto>(query.ToString());
        }

        public async Task<List<NumberCountPageList>> GetCountForGetAllPageLst(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                  ");
            query.AppendLine("	  Count(*) AS 'TotalCount' ");
            query.AppendLine("FROM dbo.[Atomic] AS R");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {AtomicTransform.CONVERT_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {AtomicTransform.CONVERT_SQL(key: input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            return await unitOfWork.FromSqlAsync<NumberCountPageList>(query.ToString());
        }

        public async Task<List<Atomic>> GetAtomicsById(List<int> ids)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT      *            ");
            query.AppendLine("FROM dbo.[Atomic] AS R ");
            query.AppendLine($" WHERE R.[Id] IN {JsonConvert.SerializeObject(ids).Replace("[", "(").Replace("]", ")")}");

            return await unitOfWork.FromSqlAsync<Atomic>(query.ToString());
        }
    }
}
