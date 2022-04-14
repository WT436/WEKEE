using Product.Domain.Shared.DataTransfer.ProductDTO;
using Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<CartBasicProductDto> GetBasicProduct(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("  SELECT                                                                                                     ");
            query.AppendLine("  	  P.[name]                      AS 'Name'                                                              ");
            query.AppendLine("       ,(SELECT [name] FROM dbo.[ProductAttribute] WHERE id = P.[Trademark] AND Types = 3)  AS 'Trademark'   ");
            query.AppendLine("  	 ,P.[FullDescription]           AS 'FullDescription'                                                   ");
            query.AppendLine("  	 ,P.[ShortDescription]          AS 'ShortDescription'                                                  ");
            query.AppendLine("  	 ,P.[HasUserAgreement]          AS 'HasUserAgreement'                                                  ");
            query.AppendLine("  	 ,P.[OrderMinimumQuantity]      AS 'OrderMinimumQuantity'                                              ");
            query.AppendLine("  	 ,P.[OrderMaximumQuantity]      AS 'OrderMaximumQuantity'                                              ");
            query.AppendLine("  	 ,P.[ShipSeparately]            AS 'ShipSeparately'                                                    ");
            query.AppendLine("  	 ,P.[IsFreeShipping]            AS 'IsFreeShipping'                                                    ");
            query.AppendLine("  	 ,P.[BackorderModeId]           AS 'BackorderModeId'                                                   ");
            query.AppendLine("  	 ,P.[DisableWishlistButton]     AS 'DisableWishlistButton'                                             ");
            query.AppendLine("  	 ,P.[WishlistNumber]            AS 'WishlistNumber'                                                    ");
            query.AppendLine("  	 ,P.[MarkAsNew]                 AS 'MarkAsNew'                                                         ");
            query.AppendLine("  	 ,P.[MarkAsNewStartDateTimeUtc] AS 'MarkAsNewStartDateTimeUtc'                                         ");
            query.AppendLine("  	 ,P.[MarkAsNewEndDateTimeUtc]   AS 'MarkAsNewEndDateTimeUtc'                                           ");
            query.AppendLine("  FROM dbo.[Product]                  AS P                                                                   ");
            query.AppendLine($" WHERE P.[id] = {id}                                                                                       ");

            var data = unitOfWork.FromSql<CartBasicProductDto>(query.ToString()).FirstOrDefault();

            StringBuilder query2 = new StringBuilder();
            query2.AppendLine("  SELECT                                                                                         ");
            query2.AppendLine("  	 PSAM.[CustomValue]                                                                         ");
            query2.AppendLine("  	,SPA.[Key]                                                                                  ");
            query2.AppendLine("  	,PSAM.[DisplayOrder]                                                                        ");
            query2.AppendLine("  FROM [Product_SpecificationAttribute_Mapping] AS PSAM                                          ");
            query2.AppendLine("  JOIN [SpecificationAttribute] AS SPA ON PSAM.[SpecificationId] = SPA.[Id]                      ");
            query2.AppendLine($"  WHERE PSAM.[ProductId] = {id} AND PSAM.[ShowOnProductPage] = 1 AND PSAM.[AllowFiltering] = 1  ");
            query2.AppendLine("  ORDER BY PSAM.[DisplayOrder] ASC                                                               ");

            data.SpecificationAttributeDtos = unitOfWork.FromSql<SpecificationAttributeDto>(query2.ToString());

            return data;
        }
    }
}
