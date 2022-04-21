using Product.Application.Interface;
using Product.Domain.BoundedContext;
using Product.Domain.CoreDomain;
using Product.Domain.ObjectValues.ConstProperty;
using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.CategoryHomePageDTO;
using Product.Infrastructure.MappingExtention;
using Product.Infrastructure.ModelQuery;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Application
{
    public class CategoryDisplayService : ICategoryDisplay
    {
        private readonly CategoryProductSqlQueries _categoryProductQueries = new CategoryProductSqlQueries();
        private readonly CategoryDisplayQueries _categoryDisplayQueries = new CategoryDisplayQueries();
        private readonly CategoryProductQuery _categoryProductQuery = new CategoryProductQuery();
        public async Task<PagedListOutput<CategoryHomePageReadDto>> GetCategoryAndCateHome(SearchOrderPageInput input)
        {
            if (CategoryHomePageBounded.IsDataDefault(PropertySearch: input.PropertySearch,
                                                        ValuesSearch: input.ValuesSearch))
            {
                var data = await _categoryProductQueries
                                 .GetAllPageLstExactNotFTS(CategoryHomePageCore
                                                           .ProcessInputRemoveIsComponent(input));
                var result = data.Select(m => MappingData
                                              .InitializeAutomapper()
                                              .Map<CategoryHomePageReadDto>(m))
                                 .ToList();
                int totalCount = await _categoryProductQuery.TotalPageCategory();
                return new PagedListOutput<CategoryHomePageReadDto>
                {
                    Items = result,
                    PageIndex = input.PageIndex,
                    PageSize = data.Count,
                    TotalPages = (totalCount / input.PageSize),
                    TotalCount = totalCount
                };
            }
            else
            {
                var data = await _categoryDisplayQueries.GetAllPageLstExactNotFTS(input: input);
                return new PagedListOutput<CategoryHomePageReadDto>
                {
                    Items = data,
                    PageIndex = 0,
                    PageSize = 0,
                    TotalPages = (0 / 1),
                    TotalCount = 0
                }; ;
            }
        }
    }
}
