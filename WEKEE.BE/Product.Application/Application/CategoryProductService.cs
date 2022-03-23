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
    public class CategoryProductService : ICategoryProduct
    {
        public async Task<int?> CreateCategory(CategoryProductInsertDto cp)
        {
            // check data With server
            CategoryProductQuery _categoryProductQuery = new CategoryProductQuery();

            // kiem tra ton tai cua NameCategory và url
            if (!await _categoryProductQuery.CheckAnyNameAndUrl(name: cp.NameCategory,
                                                                url: cp.UrlCategory))
            {
                // check icon ? null => default
                if (String.IsNullOrEmpty(cp.IconCategory))
                {
                    cp.IconCategory = DataDefault.ICON_CATEGORY_PRODUCT;
                }

                // check level and number
                int NumberOrderEnd = await _categoryProductQuery.GetNumberOrderEnd(level: cp.LevelCategory);

                // Kiểm tra tồn tại của category main
                if (!await _categoryProductQuery.ExistsCategoryMain(cp.CategoryMain) && cp.CategoryMain != 1)
                {
                    throw new ClientException(422, "Category Main");
                }

                var cateInsert = new CategoryProduct
                {
                    NameCategory = cp.NameCategory,
                    UrlCategory = cp.UrlCategory,
                    IconCategory = cp.IconCategory,
                    LevelCategory = cp.LevelCategory,
                    CategoryMain = cp.CategoryMain,
                    NumberOrder = NumberOrderEnd + 1,
                    IsEnabled = cp.IsEnabled,
                    UpdatedOnUtc = DateTime.Now,
                    CreatedOnUtc = DateTime.Now
                };

                return _categoryProductQuery.Insert(cateInsert);
            }
            else
            {
                throw new ClientException(422, "Name Or Url");
            }
        }

        public async Task<PagedListOutput<CategoryProductReadDto>> GetAllPageListCategory(SearchOrderPageInput input)
        {
            CategoryProductSqlQuery db = new CategoryProductSqlQuery();
            CategoryProductQuery dbEF = new CategoryProductQuery();
            var data = await db.GetAllPageLstExactNotFTS(input);
            int totalCount = await dbEF.TotalPageCategory();
            return new PagedListOutput<CategoryProductReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = data.Count,
                TotalPages = (totalCount / input.PageSize),
                TotalCount = totalCount
            };
        }
    }
}
