using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
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

        public async Task<int> GetNumberOrderEnd(int? level)
        {
            try
            {
                return await unitOfWork.GetRepository<CategoryProduct>()
                                       .MaxAsync(predicate: c => c.LevelCategory == level, selector: cp => cp.NumberOrder);
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<bool> ExistsCategoryMain(int? categoryMain)
        => await unitOfWork.GetRepository<CategoryProduct>()
                           .ExistsAsync(c => c.CategoryMain == categoryMain);

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

        public int Update(List<CategoryProduct> input)
        {
            unitOfWork.GetRepository<CategoryProduct>().Update(input);
            return unitOfWork.SaveChanges();
        }
        public Task<int> SaveChangeAsync()
        {
            return unitOfWork.SaveChangesAsync();
        }
    }
}
