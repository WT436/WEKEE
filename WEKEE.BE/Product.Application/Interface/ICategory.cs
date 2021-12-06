using Product.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
   public  interface ICategory
    {
        public Task<int> CreateCategory(CategoryDto categoryDto);
        public Task<List<CategoryDto>> GetListAll(int level, int? categorymain, int orderNumber);
        public Task<List<CategorySelectDto>> GetAllCategoryFullLevel();
        public Task<List<CategoryBreadcrumbDtos>> GetCategoryById(int id);
    }
}
