using Product.Application.Interface;
using Product.Domain.ObjectValues.Const;
using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.ProductTagDTO;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.ModelQuery;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Product.Application.Application
{
    public class ProductTagService : IProductTag
    {
        public readonly ProductTagQuery _productTagQuery = new ProductTagQuery();
        public readonly ProductTagQueries _productTagQueries = new ProductTagQueries();

        public async Task<PagedListOutput<ProductTagReadDto>> GetNamePageLst(SearchOrderPageInput input)
        {
            var data = await _productTagQueries.GetAllPageLstExactNotFTS(input);
            int totalCount = await _productTagQuery.TotalPageCategory();

            return new PagedListOutput<ProductTagReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = data.Count,
                TotalPages = (totalCount / input.PageSize),
                TotalCount = totalCount
            };
        }

        public async Task<int> InsertProductTag(string name, int idAccount)
        {
            var productTagName = name.Replace(" ", "_");

            if (await _productTagQuery.CheckName(productTagName: productTagName))
            {
                throw new ClientException(400, MessageOutput.EXISTS_PARAMETER);
            }

           return await _productTagQuery.Insert(new ProductTag
            {
                Name = productTagName,
                IsDelete = false,
                CreateBy = idAccount,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            });

        }
    }
}
