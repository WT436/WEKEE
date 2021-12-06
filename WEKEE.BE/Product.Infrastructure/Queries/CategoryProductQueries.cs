using Product.Domain.Entitys;
using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class CategoryProductQueries
    {

        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());

        #region Create
        public void Create(CategoryProduct categoryProduct)
        {
            unitOfWork.GetRepository<CategoryProduct>().Insert(categoryProduct);
            unitOfWork.SaveChanges();
        }

        public async Task CreateAsync(CategoryProduct categoryProduct)
        {
            await unitOfWork.GetRepository<CategoryProduct>().InsertAsync(categoryProduct);
            unitOfWork.SaveChanges();
        }

        public int CreateId(CategoryProduct categoryProduct)
        {
            unitOfWork.GetRepository<CategoryProduct>().Insert(categoryProduct);
            unitOfWork.SaveChanges();
            return categoryProduct.Id;
        }

        public async Task<int> CreateIdAsync(CategoryProduct categoryProduct)
        {
            await unitOfWork.GetRepository<CategoryProduct>().InsertAsync(categoryProduct);
            unitOfWork.SaveChanges();
            return categoryProduct.Id;
        }

        public CategoryProduct CreateCategoryProduct(CategoryProduct categoryProduct)
        {
            unitOfWork.GetRepository<CategoryProduct>().Insert(categoryProduct);
            unitOfWork.SaveChanges();
            return categoryProduct;
        }

        public async Task<CategoryProduct> CreateCategoryProductAsync(CategoryProduct categoryProduct)
        {
            await unitOfWork.GetRepository<CategoryProduct>().InsertAsync(categoryProduct);
            unitOfWork.SaveChanges();
            return categoryProduct;
        }

        #endregion

        #region Read
        public async Task<IList<CategoryProduct>> GetListCategotyOrderByAsc(int level, int? categorymain, int orderNumber)
                  => await unitOfWork.GetRepository<CategoryProduct>()
                                     .GetAllAsync(predicate: m => m.LevelCategory == level
                                                               && m.CategoryMain == categorymain
                                                               && m.NumberOrder >= orderNumber,
                                                  orderBy: o => o.OrderBy(i => i.NumberOrder));
        
        public async Task<IList<CategoryProduct>> GetListCategoty(int level)
                  => await unitOfWork.GetRepository<CategoryProduct>()
                                     .GetAllAsync(m => m.LevelCategory == level);

        public async Task<CategoryProduct> GetUnitCategoty(int id)
                  => await unitOfWork.GetRepository<CategoryProduct>()
                                     .GetFirstOrDefaultAsync(predicate: m => m.Id == id);
        #endregion

        #region Update
        public void Update(CategoryProduct categoryProduct)
        {
            unitOfWork.GetRepository<CategoryProduct>().Update(categoryProduct);
            unitOfWork.SaveChanges();
        }

        #endregion

        #region  Delete
        #endregion

        #region  Check
        public async Task<bool> CheckListCategoty(int level, int? categorymain, int orderNumber)
                  => await unitOfWork.GetRepository<CategoryProduct>()
                                     .ExistsAsync(m => m.LevelCategory == level
                                                    && m.CategoryMain == categorymain
                                                    && m.NumberOrder == orderNumber
                                               );

        public async Task<bool> CheckIdCategory(int id)
                  => await unitOfWork.GetRepository<CategoryProduct>()
                                     .ExistsAsync(m => m.Id == id);
        #endregion

        #region  Join
        #endregion
    }
}
