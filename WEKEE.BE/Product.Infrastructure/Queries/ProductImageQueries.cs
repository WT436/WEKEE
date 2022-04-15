using Product.Domain.Shared.DataTransfer.ImageProductDTO;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductImageQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<List<ImageForProductDto>> GetBasicProduct(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(" SELECT                                                                       ");
            query.AppendLine(" 	    I.[ImageRoot]		 AS 'ImageRoot'                                     ");
            query.AppendLine(" 	   ,I.[VirtualPath]		 AS 'VirtualPath'                                   ");
            query.AppendLine(" 	   ,I.[Size] 			 AS 'Size'                                          ");
            query.AppendLine(" 	   ,I.[IsCover]			 AS 'IsCover'                                       ");
            query.AppendLine(" 	   ,I.[AltAttribute]	 AS 'AltAttribute'                                  ");
            query.AppendLine(" 	   ,I.[SeoFilename]		 AS 'SeoFilename'                                   ");
            query.AppendLine(" 	   ,I.[TitleAttribute]	 AS 'TitleAttribute'                                ");
            query.AppendLine(" 	   ,PIM.[DisplayOrder]	 AS 'DisplayOrder'                                  ");
            query.AppendLine(" FROM ImageProduct AS I                                                       ");
            query.AppendLine(" INNER JOIN Product_Picture_Mapping AS PIM ON I.Id = PIM.PictureId            ");
            query.AppendLine($" WHERE PIM.ProductId = {id} AND PIM.isDelete = 0                             ");
            query.AppendLine(" AND (I.[Size] = 'S80x80' OR I.[Size] = 'S1360x540' OR I.[Size] = 'S340x340') ");

            var data = await unitOfWork.FromSqlAsync<ImageForProductDto>(query.ToString());

            return data;
        }
    }
}
