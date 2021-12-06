using Product.Application.Interface;
using Product.Domain.Aggregate;
using Product.Domain.BoundedContext;
using Product.Domain.Dto;
using Product.Domain.Entitys;
using Product.Infrastructure.MappingExtention;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;
using Utils.Extensions;

namespace Product.Application.Application
{
    public class ACategory : ICategory
    {
        private readonly CategoryProductQueries _categoryProductQueries = new CategoryProductQueries();
        private readonly ProductQueries _productQueries = new ProductQueries();

        public async Task<List<CategorySelectDto>> GetAllCategoryFullLevel()
        {
            var dataLv1 = await _categoryProductQueries.GetListCategoty(1);
            var dataLv2 = await _categoryProductQueries.GetListCategoty(2);
            var dataLv3 = await _categoryProductQueries.GetListCategoty(3);
            var dataLv4 = await _categoryProductQueries.GetListCategoty(4);

            return new ProcessCategory().MapFullCategory(dataLv1: dataLv1,
                                                         dataLv2: dataLv2,
                                                         dataLv3: dataLv3,
                                                         dataLv4: dataLv4);
        }

        public async Task<int> CreateCategory(CategoryDto categoryDto)
        {
            // check
            CheckData.CheckSpecial(categoryDto.NameCategory);
            CheckData.CheckSpecial(categoryDto.UrlCategory);
            // logic
            bool categoryMain = categoryDto.CategoryMain == 0;
            if (categoryDto.LevelCategory == 1 && !categoryMain && categoryDto.IconCategory == null)
            {
                throw new ClientException(400, "Main category need icon!");
            }

            if (categoryDto.LevelCategory != 1 && !categoryMain && categoryDto.IconCategory != null)
            {
                throw new ClientException(400, "Category without icon!");
            }

            if (await _categoryProductQueries.CheckListCategoty(level: categoryDto.LevelCategory,
                                                                categorymain: categoryDto.CategoryMain,
                                                                orderNumber: categoryDto.NumberOrder))
            {
                // order
                var data = await _categoryProductQueries.GetListCategotyOrderByAsc(level: categoryDto.LevelCategory,
                                                                                   categorymain: categoryDto.CategoryMain,
                                                                                   orderNumber: categoryDto.NumberOrder);

                if (data.Count != 0)
                {
                    foreach (var item in data.ToList())
                    {
                        item.NumberOrder++;
                        _categoryProductQueries.Update(item);
                    }
                }
            }
            await _categoryProductQueries.CreateAsync(categoryProduct: MappingData.InitializeAutomapper()
                                                                                  .Map<CategoryProduct>(categoryDto));
            return 1;
        }

        public async Task<List<CategoryDto>> GetListAll(int level, int? categorymain, int orderNumber)
        {
            var data = await _categoryProductQueries.GetListCategotyOrderByAsc(level: level,
                                                                                    categorymain: categorymain,
                                                                                    orderNumber: orderNumber);

            return data.Select(m => MappingData.InitializeAutomapper().Map<CategoryDto>(m)).ToList();
        }

        public async Task<List<CategoryBreadcrumbDtos>> GetCategoryById(int id)
        {
            if (id == 0) throw new ClientException(500, "Sản phẩm Lỗi");
            //lấy category từ product
            var product = await _productQueries.GetUnitProduct(id);
            id = (int)product.CategoryProduct;
            // lấy thông tin category
            List<CategoryBreadcrumbDtos> categoryBreadcrumbDtos = new List<CategoryBreadcrumbDtos>();
            do
            {
                var category = await _categoryProductQueries.GetUnitCategoty(id);
                var dataCategory = MappingData.InitializeAutomapper().Map<CategoryBreadcrumbDtos>(category);
                categoryBreadcrumbDtos.Add(dataCategory);
                id = (int)category.CategoryMain;
            } while (id != 0);

            return categoryBreadcrumbDtos;
        }
    }
}
