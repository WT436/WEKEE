using Product.Domain.Shared.DataTransfer.CategoryProductDTO;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class CategoryProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<bool> CheckAnyNameAndUrl(string name, string url)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .ExistsAsync(c => c.NameCategory == name || c.UrlCategory == url);

        public async Task<int> GetNumberOrderEnd(int? level, int number)
        {
            var IsNumberOrderExists = await unitOfWork.GetRepository<CategoryProduct>()
                                                      .ExistsAsync(c => c.LevelCategory == level && c.NumberOrder == number);
            if (IsNumberOrderExists)
            {
                return await unitOfWork.GetRepository<CategoryProduct>()
                                       .MaxAsync(predicate: c => c.LevelCategory == level, selector: cp => cp.NumberOrder);
            }
            else
            {
                return number;
            }
        }

        public async Task<int> GetNumberOrderEnd(int? level, int? categoryMain)
        {
            try
            {
                return await unitOfWork.GetRepository<CategoryProduct>()
                                       .MaxAsync(predicate: c => c.LevelCategory == level && c.CategoryMain == (categoryMain == 0 ? null : categoryMain),
                                                 selector: cp => cp.NumberOrder);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> ExistsCategoryMain(int? categoryMain)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .ExistsAsync(c => c.CategoryMain == categoryMain);

        public async Task<int> GetLevelCategoryMain(int? categoryMain)
        {
            CategoryProduct data = await unitOfWork.GetRepository<CategoryProduct>()
                                                   .GetFirstOrDefaultAsync(predicate: c => c.Id == categoryMain);

            return data == null ? -1 : Convert.ToInt32(data.LevelCategory + 1);
        }

        public int Insert(CategoryProduct categoryProduct)
        {
            unitOfWork.GetRepository<CategoryProduct>().Insert(categoryProduct);
            return unitOfWork.SaveChanges();
        }

        public async Task<int> TotalPageCategory()
        => (await unitOfWork.GetRepository<CategoryProduct>()
                           .CountAsync());

        public async Task<CategoryProduct> GetDataByIdAndNumberOrder(int? idMain, int level, int number)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .GetFirstOrDefaultAsync(predicate: c => c.CategoryMain == idMain
                                                           && c.LevelCategory == level
                                                           && c.NumberOrder == number);

        public async Task<CategoryProduct> GetDataById(int id)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .GetFirstOrDefaultAsync(predicate: c => c.Id == id);

        public async Task<bool> CheckAnyById(int id)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .ExistsAsync(m => m.Id == id);

        public int Update(List<CategoryProduct> input)
        {
            unitOfWork.GetRepository<CategoryProduct>().Update(input);
            return unitOfWork.SaveChanges();
        }

        public int Update(CategoryProduct input)
        {
            unitOfWork.GetRepository<CategoryProduct>().Update(input);
            return unitOfWork.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            return unitOfWork.SaveChangesAsync();
        }

        public async Task<List<CategoryProductReadMapDto>> GetMapCategoryProduct()
        => (unitOfWork.GetRepository<CategoryProduct>()
                    .GetAll(predicate: m => m.LevelCategory == 1))
                    .ToList()
                    .Select(n1 => new CategoryProductReadMapDto()
                    {
                        Id = n1.Id,
                        NameCategory = n1.NameCategory,
                        Items = (unitOfWork.GetRepository<CategoryProduct>()
                                           .GetAll(predicate: m2 => m2.LevelCategory == 2 && m2.CategoryMain == n1.Id))
                                           .ToList()
                                           .Select(n2 => new CategoryProductReadMapDto
                                           {
                                               Id = n2.Id,
                                               NameCategory = n2.NameCategory,
                                               Items = (unitOfWork.GetRepository<CategoryProduct>()
                                                                  .GetAll(predicate: m3 => m3.LevelCategory == 3 && m3.CategoryMain == n2.Id))
                                                                  .ToList()
                                                                  .Select(n3 => new CategoryProductReadMapDto
                                                                  {
                                                                      Id = n3.Id,
                                                                      NameCategory = n3.NameCategory,
                                                                      Items = null
                                                                  }).ToList()
                                           }).ToList()
                    }).ToList();
    }
}
