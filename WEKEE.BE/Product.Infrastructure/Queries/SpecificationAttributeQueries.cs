using Product.Domain.ObjectValues.Const;
using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer;
using Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class SpecificationAttributeQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<SpecificationAttributeReadDto>> GetAllPageLstExactNotFTS(SearchOrderPageInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("  SELECT                                                            ");
            query.AppendLine("		  		CP.id                 AS 'Id',                        ");
            query.AppendLine("				CP.[key]			  AS 'Key',                       ");
            query.AppendLine("				CP.GroupSpecification AS 'GroupSpecification',        ");
            query.AppendLine("		        CP.CategoryProductId  AS 'CategoryProductId',         ");
            query.AppendLine("				CP.CreateBy			  AS 'CreateBy',                  ");
            query.AppendLine("		  		CP.CreatedOnUtc       AS 'CreatedOnUtc',              ");
            query.AppendLine("		  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '              ");
            query.AppendLine("	FROM SpecificationAttribute      AS CP                            ");

            if (input.PropertySearch != null)
            {
                for (int i = 0; i < input.PropertySearch.Length; i++)
                {
                    if (i == 0)
                        query.AppendLine($" WHERE {SpecificationAttributeProperty.CONVERT_PROPERTY_SPEC(key: input.PropertySearch[0], value: input.ValuesSearch[0])}");
                    else
                        query.AppendLine($" AND {SpecificationAttributeProperty.CONVERT_PROPERTY_SPEC(input.PropertySearch[i], value: input.ValuesSearch[i])}");
                }
            }
            query.AppendLine($"  ORDER BY {SpecificationAttributeProperty.CONVERT_PROPERTY_SPEC(input.PropertyOrder)} {OrderByProperty.CONVERT_ORDER_BY(input.ValueOrderBy)} ");
            query.AppendLine($"  OFFSET(({input.PageIndex} - 1) * {input.PageSize}) ROWS                                                                        ");
            query.AppendLine($"  FETCH NEXT {input.PageSize} ROWS ONLY                                                                            ");

            return unitOfWork.FromSql<SpecificationAttributeReadDto>(query.ToString());
        }
    }
}
