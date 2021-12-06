using Product.Domain.Entitys;
using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;

namespace Product.Infrastructure.Queries
{
    public class SpecificationsCategoryQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                       new UnitOfWork<ProductDBContext>(new ProductDBContext());

        #region Create
        public async Task<int> Create(SpecificationsCategory specificationsCategory)
        {
            await unitOfWork.GetRepository<SpecificationsCategory>()
                            .InsertAsync(specificationsCategory);
            unitOfWork.SaveChanges();
            return 1;
        }
        #endregion

        #region Read
        public IQueryable<SpecificationsCategory> GetListAllData()
            => unitOfWork.GetRepository<SpecificationsCategory>()
                         .GetAll();

        public async Task<List<string>> GetAllKeyDistinct()
        {
            var data = await unitOfWork.GetRepository<SpecificationsCategory>()
                                   .GetAllAsync();

            return data.Select(m => m.Key).Distinct().ToList();
        }

        public async Task<List<string>> GetAllClassifyValuesDistinct(string key)
        {
            var data = await unitOfWork.GetRepository<SpecificationsCategory>()
                                   .GetAllAsync(predicate: m => m.Key.ToUpper() == key.ToUpper());

            return data.Select(m => m.ClassifyValues).Distinct().ToList();
        }

        public async Task<List<SpecificationsCategory>> GetAllCateryAndNullCategory(int? category)
        {
            var data = await unitOfWork.GetRepository<SpecificationsCategory>()
                                   .GetAllAsync(predicate: m => m.CategoryMain == category || m.CategoryMain == null);

            return data.Distinct().ToList();
        }

        #endregion

        #region Update
        #endregion

        #region  Delete
        #endregion

        #region  Join
        #endregion
    }
}
