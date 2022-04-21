using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer.CategoryHomePageDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class CategoryDisplayQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<CategoryHomePageReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(" SELECT                                                        ");
            query.AppendLine(" 	    CP.[nameCategory]  AS 'NameCategory'                     ");
            query.AppendLine(" 	   ,CP.[urlCategory]   AS 'UrlCategory'                      ");
            query.AppendLine(" 	   ,CP.[iconCategory]  AS 'IconCategory'                     ");
            query.AppendLine(" 	   ,CP.[categoryMain]  AS 'CategoryMain'                     ");
            query.AppendLine(" 	   ,CHP.[id]		   AS 'Id'                               ");
            query.AppendLine(" 	   ,CHP.[numberOrder]  AS 'NumberOrder'                      ");
            query.AppendLine(" 	   ,CHP.[isEnabled]	   AS 'IsEnabled'                        ");
            query.AppendLine(" 	   ,CHP.[isComponent]  AS 'IsComponent'                      ");
            query.AppendLine(" 	   ,CHP.[CreateBy]	   AS 'CreateBy'                         ");
            query.AppendLine(" 	   ,CHP.[createdOnUtc] AS 'CreatedOnUtc'                     ");
            query.AppendLine(" 	   ,CHP.[updatedOnUtc] AS 'UpdatedOnUtc'                     ");
            query.AppendLine(" FROM [CategoryProduct] AS CP                                  ");
            query.AppendLine(" JOIN [CategoryHomePage] AS CHP ON CP.[id] = CHP.[categoryId]  ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {ConvertPropertyCategoryHomePage.CONVERT_PROPERTY_KEY_TO_SQL(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {ConvertPropertyCategoryHomePage.CONVERT_PROPERTY_KEY_TO_SQL(input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }

            query.AppendLine($"  ORDER BY {ConvertPropertyCategoryHomePage.CONVERT_PROPERTY_KEY_TO_SQL(input.PropertyOrder)} {OrderByProperty.CONVERT_ORDER_BY(input.ValueOrderBy)} ");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return await unitOfWork.FromSqlAsync<CategoryHomePageReadDto>(query.ToString());
        }
    }
}
