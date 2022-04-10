using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer.ProductAttributeDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductAttributeQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<ProductAttributeReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("  SELECT CP.[Id]              AS 'Id'                                                                                        ");
            query.AppendLine("	    ,CP.[Name]              AS 'Name'                                                                                      ");
            query.AppendLine("	    ,CP.[Types]             AS 'Types'                                                                                     ");
            query.AppendLine("	    ,CP.[CategoryProductId] AS 'CategoryProductId'                                                                         ");
            query.AppendLine("	    ,(SELECT [nameCategory] FROM [CategoryProduct] WHERE id = CP.[CategoryProductId])	 AS 'CategoryProductIdName'        ");
            query.AppendLine("	    ,CP.[isDelete]          AS 'IsDelete'                                                                                  ");
            query.AppendLine("	    ,CP.[CreateBy]          AS 'CreateBy'                                                                                  ");
            query.AppendLine("	    ,CP.[CreatedOnUtc]      AS 'CreatedOnUtc'                                                                              ");
            query.AppendLine("	    ,CP.[UpdatedOnUtc]      AS 'UpdatedOnUtc'                                                                              ");
            query.AppendLine("	FROM[ProductDB].[dbo].[ProductAttribute] AS CP                                                                             ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {ProductAttributeProperty.CONVERT_PROPERTY(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {ProductAttributeProperty.CONVERT_PROPERTY(input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }
            query.AppendLine($"  ORDER BY {ProductAttributeProperty.CONVERT_PROPERTY(input.PropertyOrder)} {OrderByProperty.CONVERT_ORDER_BY(input.ValueOrderBy)} ");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return unitOfWork.FromSql<ProductAttributeReadDto>(query.ToString());
        }

        public async Task<List<ProductAttributeReadTypesDto>> GetAllTypesProductAttribute(int type)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("  SELECT distinct                      ");
            query.AppendLine("         CP.[Id]                       ");
            query.AppendLine("  	  ,CP.[Name]                     ");
            query.AppendLine("  	  ,CP.[Types]                    ");
            query.AppendLine("  FROM[dbo].[ProductAttribute] AS CP   ");
            query.AppendLine($"  WHERE CP.Types = {type}             ");
            query.AppendLine("    AND CP.CreateBy = 0                ");
            query.AppendLine("    AND CP.isDelete = 0                ");

            return unitOfWork.FromSql<ProductAttributeReadTypesDto>(query.ToString());
        }
    }
}
