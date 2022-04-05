using Product.Application.Interface;
using Product.Domain.ObjectValues.Const;
using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.ProductAttributeDTO;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.EventBus;
using Product.Infrastructure.ModelQuery;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Product.Application.Application
{
    public class ProductAttributeService : IProductAttribute
    {
        ProductAttributeQuery _productAttributeQuery = new ProductAttributeQuery();
        ProductAttributeQueries _productAttributeQueries = new ProductAttributeQueries();
        AccountBus _accountBus = new AccountBus();

        public async Task<PagedListOutput<ProductAttributeReadDto>> GetAllPageListProductAttribute(SearchOrderPageInput input)
        {
            var data = await _productAttributeQueries.GetAllPageLstExactNotFTS(input);
            int totalCount = await _productAttributeQuery.TotalPageCategory();
            foreach(var item in data)
            {
                item.TypesName = ProductAttributeTypesConvert.ConvertAttributeTypes(item.Types);
                item.CreateByName = await _accountBus.GetNameAccount(item.CreateBy);
            }
            return new PagedListOutput<ProductAttributeReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = data.Count,
                TotalPages = (totalCount / input.PageSize),
                TotalCount = totalCount
            };
        }

        public async Task<int> InsertProductAttribute(ProductAttributeInsertDto input, int idAccount)
        {
            // check name + type any
            if (await _productAttributeQuery.CheckNameAndTypeExists(name: input.Name, type: input.Types))
            {
                throw new ClientException(422, MessageOutput.EXISTS_PARAMETER);
            }
            else
            {
                _productAttributeQuery.Insert(new ProductAttribute
                {
                    Name = input.Name,
                    Types = input.Types,
                    IsDelete = false,
                    CreateBy = idAccount,
                    CreatedOnUtc = DateTime.Now,
                    UpdatedOnUtc = DateTime.Now
                });
                return 1;
            }
        }
    }
}
