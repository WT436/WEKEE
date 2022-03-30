using Product.Application.Interface;
using Product.Domain.CoreDomain;
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
        // check data With server
        public readonly CategoryProductQuery _categoryProductQuery = new CategoryProductQuery();
        private readonly IImageProduct _imageProduct = new ImageProductService();
        public async Task<int> ChangeEnableCategory(List<Entitys> id)
        {
            int countUpdate = 0;
            foreach (var category in id)
            {
                var data = await _categoryProductQuery.GetDataById(category.Id);
                if (data != null)
                {
                    data.IsEnabled = !data.IsEnabled;
                    data.UpdatedOnUtc = DateTime.Now;
                    _categoryProductQuery.Update(data);
                    countUpdate++;
                }
            }
            return countUpdate;
        }

        public async Task<int> ChangeNumberOrder(List<CategoryProductNumberOrderDto> input)
        {
            if (input == null || input.Count == 0)
            {
                return 0;
            }

            //else if (input.Count == 1)
            //{
            //    // bản ghi có vị trí mà bản ghi này muốn đổi chỗ
            //    var categoryLate = await _categoryProductQuery.GetDataByIdAndNumberOrder(idMain: input[0].CategoryMain,
            //                                                                                     level: input[0].LevelCategory,
            //                                                                                    number: input[0].NumberOrder);
            //    // bản ghi này
            //    var categoryFirst = await _categoryProductQuery.GetDataById(id: input[0].Id);
            //    var data = CategoryProductCore.CategoryProductsSwapNumberOrder(categoryFirst, categoryLate);
            //    return _categoryProductQuery.Update(data);
            //}

            else
            {
                int sumUpdate = 0;
                foreach (var item in input)
                {
                    // bản ghi có vị trí mà bản ghi này muốn đổi chỗ
                    var categoryLate = await _categoryProductQuery.GetDataByIdAndNumberOrder(idMain: item.CategoryMain,
                                                                                             level: item.LevelCategory,
                                                                                             number: item.NumberOrder);
                    // bản ghi này
                    var categoryFirst = await _categoryProductQuery.GetDataById(id: item.Id);
                    var data = CategoryProductCore.CategoryProductsSwapNumberOrder(categoryFirst, categoryLate);
                    if (data != null)
                    {
                        _categoryProductQuery.Update(data);
                        sumUpdate++;
                    }
                }
                return sumUpdate;
            }
        }

        public async Task<int?> CreateCategory(CategoryProductInsertDto cp)
        {
            // kiem tra ton tai cua NameCategory và url
            if (!await _categoryProductQuery.CheckAnyNameAndUrl(name: cp.NameCategory,
                                                                url: cp.UrlCategory))
            {
                // check icon ? null => default
                if (String.IsNullOrEmpty(cp.IconCategory))
                {
                    cp.IconCategory = DataDefault.ICON_CATEGORY_PRODUCT;
                }

                // từ category Main => level = level Categorymain + 1
                var levelCategogyMain = cp.CategoryMain == null || cp.CategoryMain == 0 
                                        ? 1 
                                        : await _categoryProductQuery.GetLevelCategoryMain(cp.CategoryMain);

                if (levelCategogyMain == -1)
                {
                    throw new ClientException(422, "Category-Main");
                }
                // Từ category Main + level => NumberOrderMax

                // Kiểm tra tồn tại của category main và level của chúng

                // check level and number
                int NumberOrderEnd = await _categoryProductQuery.GetNumberOrderEnd(level: levelCategogyMain,
                                                                                   categoryMain: cp.CategoryMain);
                var iconCategory = await _imageProduct.InsertImageCategory(cp.IconCategory, cp.NameCategory);

                var cateInsert = new CategoryProduct
                {
                    NameCategory = cp.NameCategory,
                    UrlCategory = cp.UrlCategory,
                    IconCategory = iconCategory,
                    LevelCategory = Convert.ToInt32(levelCategogyMain),
                    CategoryMain = cp.CategoryMain == 0 ? null : cp.CategoryMain,
                    NumberOrder = NumberOrderEnd + 1,
                    IsEnabled = cp.IsEnabled,
                    UpdatedOnUtc = DateTime.Now,
                    CreatedOnUtc = DateTime.Now
                };

                return _categoryProductQuery.Insert(cateInsert);
            }
            else
            {
                throw new ClientException(422, "Name-Or-Url");
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

        public async Task<List<CategoryProductReadMapDto>> GetMapCategory()
        {
            var data = await _categoryProductQuery.GetMapCategoryProduct();
            return data;
        }

        public Task<int> MoveCategoryMain(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryProductReadChildrenDto> SearchAllCategory(SearchOrderPageInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateInfoCategory(CategoryProductUpdateDto input)
        {
            // check name , url exsts
            if (await _categoryProductQuery.CheckAnyNameAndUrl(input.NameCategory, url: input.UrlCategory))
            {
                throw new ClientException(422, "Name_Or_Url");
            }
            else
            {
                var data = await _categoryProductQuery.GetDataById(input.Id);
                data.NameCategory = input.NameCategory;
                data.UrlCategory = input.UrlCategory;
                data.IconCategory = 0;
                data.IsEnabled = input.IsEnabled;
                data.UpdatedOnUtc = DateTime.Now;
                return _categoryProductQuery.Update(data);
            }
        }

    }
}
