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
        CategoryProductQuery _categoryProduct = new CategoryProductQuery();
        AccountBus _accountBus = new AccountBus();

        public async Task<PagedListOutput<ProductAttributeReadDto>> GetAllPageListProductAttribute(SearchOrderPageInput input)
        {
            var data = await _productAttributeQueries.GetAllPageLstExactNotFTS(input);
            int totalCount = await _productAttributeQuery.TotalPageCategory();
            foreach (var item in data)
            {
                item.TypesName = ProductAttributeTypesConvert.ConvertAttributeTypes(item.Types);
                var cateName = await _accountBus.GetNameAccount(item.CreateBy);
                item.CreateByName = cateName.ToUpper() == "NULL" ? "System" : cateName;
            }
            return new PagedListOutput<ProductAttributeReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
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
                    CategoryProductId = input.CategoryProductId == -1 ? null : input.CategoryProductId,
                    IsDelete = false,
                    CreateBy = idAccount,
                    CreatedOnUtc = DateTime.Now,
                    UpdatedOnUtc = DateTime.Now
                });
                return 1;
            }
        }

        public async Task<List<ProductAttributeReadTypesDto>> GetAllAttribute(int type, List<int> categorys)
        {
            List<ProductAttributeReadTypesDto> data = new List<ProductAttributeReadTypesDto>();
            if (categorys.Count==0)
            {
                data = await _productAttributeQueries.GetAllTypesProductAttribute(type);
            }
            else
            {
                data = await _productAttributeQueries.GetAllTypesProductAttribute(type, categorys);
            }
            return data;
        }

        public async Task<List<CateProReadIdAndNameDto>> CateProReadIdAndNameAccount()
        {
            var data = await _productAttributeQuery.CateProReadIdAccount();
            List<CateProReadIdAndNameDto> cateProReadIdAndNameDtos = new List<CateProReadIdAndNameDto>();
            foreach (var item in data)
            {
                var cateName = await _accountBus.GetNameAccount(item);

                cateProReadIdAndNameDtos.Add(
                new CateProReadIdAndNameDto
                {
                    Id = item,
                    Name = cateName.ToUpper() == "NULL" ? "System" : cateName
                });
            }
            return cateProReadIdAndNameDtos;
        }
    }
}
