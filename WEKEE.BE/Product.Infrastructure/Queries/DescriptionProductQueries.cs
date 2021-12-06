using Product.Infrastructure.DBContext;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class DescriptionProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
              new UnitOfWork<ProductDBContext>(new ProductDBContext());

        #region Create
        #endregion

        #region Read
        #endregion

        #region Update
        #endregion

        #region  Delete
        #endregion

        #region  Join
        #endregion
    }
}
