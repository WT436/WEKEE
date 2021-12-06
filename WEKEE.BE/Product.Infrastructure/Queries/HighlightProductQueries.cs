using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class HighlightProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());
        #region Create
        public async Task<Domain.Entitys.HighlightProduct> Create(Domain.Entitys.HighlightProduct highlightProduct)
        {
            await unitOfWork.GetRepository<Domain.Entitys.HighlightProduct>().InsertAsync(highlightProduct);
            unitOfWork.SaveChanges();
            return highlightProduct;
        }
        #endregion

        #region Read
        public async Task<List<Domain.Entitys.HighlightProduct>> GetFeatureProductById(int id)
        {
            return (await unitOfWork.GetRepository<Domain.Entitys.HighlightProduct>()
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
