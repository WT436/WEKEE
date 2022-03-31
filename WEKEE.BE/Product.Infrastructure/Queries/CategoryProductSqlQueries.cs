using Product.Domain.Shared.DataTransfer;
using Product.Domain.ObjectValues.Const;
using Product.Domain.ObjectValues.Input;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.Shared.DataTransfer.CategoryProductDTO;

namespace Product.Infrastructure.Queries
{
    public class CategoryProductSqlQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<CategoryProductReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("     SELECT                                                                                           ");
            query.AppendLine("  		CP.id                 AS 'Id',                                                              ");
            query.AppendLine("  		CP.nameCategory       AS 'NameCategory',                                                    ");
            query.AppendLine("  		CP.urlCategory        AS 'UrlCategory',                                                     ");
            query.AppendLine("  		(SELECT VirtualPath FROM ImageProduct where id = CP.iconCategory) AS 'IconCategory',        ");
            query.AppendLine("  		CP.levelCategory      AS 'LevelCategory',                                                   ");
            query.AppendLine("  		CP.categoryMain       AS 'CategoryMain',                                                    ");
            query.AppendLine("  		(SELECT nameCategory FROM CategoryProduct where id = CP.categoryMain) AS 'CategoryMainName',");
            query.AppendLine("  		CP.numberOrder        AS 'NumberOrder',                                                     ");
            query.AppendLine("  		CP.isEnabled          AS 'IsEnabled',                                                       ");
            query.AppendLine("  		CP.CreatedOnUtc       AS 'CreatedOnUtc',                                                    ");
            query.AppendLine("  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '                                                    ");
            query.AppendLine("  	FROM CategoryProduct      AS CP                                                                 ");
            
            if(input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {CategoryProductProperty.CONVERT_PROPERTY_CATEGORY(key:input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {CategoryProductProperty.CONVERT_PROPERTY_CATEGORY(input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }
            query.AppendLine($"  ORDER BY {CategoryProductProperty.CONVERT_PROPERTY_CATEGORY(input.PropertyOrder)} {OrderByProperty.CONVERT_ORDER_BY(input.ValueOrderBy)} ");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return unitOfWork.FromSql<CategoryProductReadDto>(query.ToString());
        }

    }
}
