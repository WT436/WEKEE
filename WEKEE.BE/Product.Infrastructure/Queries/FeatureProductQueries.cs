using Product.Domain.Shared.DataTransfer.ProductDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class FeatureProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<ProductReadForCartDto>> GetBasicProduct(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT                                                                                                                             ");
            query.AppendLine("		FP.[Id]				AS 'Id'                                                                                                  ");
            query.AppendLine("	   ,FP.[Price]			AS 'Price'                                                                                               ");
            query.AppendLine("	   ,FP.[Quantity]		AS 'Quantity'                                                                                            ");
            query.AppendLine("	   ,FP.[DisplayOrder]	AS 'DisplayOrder'                                                                                        ");
            query.AppendLine("	   ,FP.[MainProduct]	AS 'MainProduct'                                                                                         ");
            query.AppendLine("	   ,IMG.[Id]            AS 'IdImg'                                                                                               ");
            query.AppendLine("	   ,(SELECT VirtualPath FROM dbo.[ImageProduct] AS IIP WHERE IIP.ImageRoot = IMG.[Id] AND IIP.Size = 'S80x80') AS 'IMGS80x80'    ");
            query.AppendLine("	   ,PAV.[Values]		AS 'Values'                                                                                              ");
            query.AppendLine("	   ,PA.[Name]			AS 'Name'                                                                                                ");
            query.AppendLine("FROM dbo.[FeatureProduct] AS FP                                                                                                    ");
            query.AppendLine("INNER JOIN dbo.[ImageProduct] AS IMG ON FP.[PictureId] =  IMG.[Id]                                                                 ");
            query.AppendLine("INNER JOIN dbo.[ProductAttributeMapping] AS PAM ON FP.[Id] = PAM.[FeatureProductId]                                                ");
            query.AppendLine("INNER JOIN dbo.[ProductAttributeValue] AS PAV ON PAV.[Id] = PAM.[ProductAttributeValuesId]                                         ");
            query.AppendLine("INNER JOIN dbo.[ProductAttribute] AS PA ON PAV.[Key] = PA.[Id]                                                                     ");
            query.AppendLine($"WHERE FP.[ProductId] = {id} ORDER BY FP.[DisplayOrder]                                                                            ");

            var data = await unitOfWork.FromSqlAsync<ProductReadForCartDto>(query.ToString());

            return data;
        }
    }
}
