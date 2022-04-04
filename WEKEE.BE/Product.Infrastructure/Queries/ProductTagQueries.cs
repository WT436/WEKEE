using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer.ProductTagDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductTagQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<ProductTagReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("  SELECT CP.[Id]            AS 'Id'          ");
            query.AppendLine("	      ,CP.[Name]          AS 'Name'        ");
            query.AppendLine("	FROM [ProductDB].[dbo].[ProductTag] AS CP  ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {ProductTagProperty.CONVERT_PROPERTY(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {ProductTagProperty.CONVERT_PROPERTY(input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }
            query.AppendLine($"  ORDER BY {ProductTagProperty.CONVERT_PROPERTY(input.PropertyOrder)} {OrderByProperty.CONVERT_ORDER_BY(input.ValueOrderBy)} ");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return unitOfWork.FromSql<ProductTagReadDto>(query.ToString());
        }

    }
}
