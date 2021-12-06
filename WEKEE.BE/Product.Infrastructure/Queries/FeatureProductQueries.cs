using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class FeatureProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());
        #region Create
        #endregion

        #region Read
        public async Task<Domain.Entitys.FeatureProduct> Create(Domain.Entitys.FeatureProduct featureProduct)
        {
            await unitOfWork.GetRepository<Domain.Entitys.FeatureProduct>().InsertAsync(featureProduct);
            unitOfWork.SaveChanges();
            return featureProduct;
        }

        public async Task<List<Domain.Entitys.FeatureProduct>> GetFeatureProductById(int id)
        {
            return (await unitOfWork.GetRepository<Domain.Entitys.FeatureProduct>()
                                    .GetAllAsync(m => m.Product == id))
                   .ToList();
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
