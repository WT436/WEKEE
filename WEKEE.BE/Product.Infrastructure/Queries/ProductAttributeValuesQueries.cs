using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductAttributeValuesQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                       new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public List<ProductAttributeValueReadDto> ReadByKey(int idKey)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("   SELECT distinct                                                                      ");
            query.AppendLine("	       CP.[Id]   AS 'Id'                                                              ");
            query.AppendLine("	  	  ,CP.[Key]  AS 'Key'                                                             ");
            query.AppendLine("		  ,(SELECT [Name] FROM [dbo].[ProductAttribute] WHERE Id = CP.[Key]) AS 'KeyName' ");
            query.AppendLine("	  	  ,CP.[Values]    AS 'Values'                                                     ");
            query.AppendLine("	  FROM [dbo].[ProductAttributeValue] AS CP                                            ");
            query.AppendLine($"	  WHERE CP.[Key] = {idKey}                                                             ");
            
            return unitOfWork.FromSql<ProductAttributeValueReadDto>(query.ToString());
        }
    }
}
