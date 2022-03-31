using Product.Application.Interface;
using Product.Domain.ObjectValues.Const;
using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer;
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
    public class SpecificationAttributeService : ISpecificationAttribute
    {
        private readonly CategoryProductQuery _categoryProductQuery = new CategoryProductQuery();
        private readonly SpecificationAttributeQuery _specificationAttributeQuery = new SpecificationAttributeQuery();
        private readonly SpecificationAttributeQueries _specificationAttributeQueries = new SpecificationAttributeQueries();

        public async Task<PagedListOutput<SpecificationAttributeReadDto>> GetAllPageListCategory(SearchOrderPageInput input)
        {
            var data = await _specificationAttributeQueries.GetAllPageLstExactNotFTS(input);
            int totalCount = await _specificationAttributeQuery.TotalPageCategory();

            return new PagedListOutput<SpecificationAttributeReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = data.Count,
                TotalPages = (totalCount / input.PageSize),
                TotalCount = totalCount
            };
        }

        public async Task<int> Insert(SpecificationAttributeInsertDto input, int idAccount)
        {
            // kiem tra category
            if (!await _categoryProductQuery.CheckAnyById(id: input.CategoryProductId))
                throw new ClientException(400, MessageOutput.CATEGORY_NOT_EXISTS);
            // kiem tra nhom và category
            if (!string.IsNullOrEmpty(input.GroupSpecification))
            {
                if (await _specificationAttributeQuery.CheckCategoryAndGroupAndKey(idCategory: input.CategoryProductId,
                                                                                        group: input.GroupSpecification,
                                                                                          key: input.Key))
                {
                    throw new ClientException(400, MessageOutput.SPECIFICATION_ATTRIBUTE_NOT_INSERT);
                }
                else
                {
                    _specificationAttributeQuery.Insert(new SpecificationAttribute
                    {
                        Key = input.Key,
                        CategoryProductId = input.CategoryProductId,
                        GroupSpecification = input.GroupSpecification,
                        CreateBy = idAccount,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow
                    });
                    return 1;
                }
            }
            else
            {
                if (await _specificationAttributeQuery.CheckCategoryAndGroupAndKey(idCategory: input.CategoryProductId,
                                                                                        group: "",
                                                                                          key: input.Key))
                {
                    throw new ClientException(400, MessageOutput.SPECIFICATION_ATTRIBUTE_NOT_INSERT);
                }
                else
                {
                    _specificationAttributeQuery.Insert(new SpecificationAttribute
                    {
                        Key = input.Key,
                        CategoryProductId = input.CategoryProductId,
                        GroupSpecification = "",
                        CreateBy = idAccount,
                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow
                    });
                    return 1;
                }
            }
            // kiem tra key và category và nhóm nếu có
            // Insert
        }
   
    }
}
