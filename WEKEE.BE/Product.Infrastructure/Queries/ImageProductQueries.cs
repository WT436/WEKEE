using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ImageProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());
        #region Create
        public async Task<Domain.Entitys.ImageProduct> Create(Domain.Entitys.ImageProduct imageProduct)
        {
            await unitOfWork.GetRepository<Domain.Entitys.ImageProduct>().InsertAsync(imageProduct);
            unitOfWork.SaveChanges();
            return imageProduct;
        }
        #endregion

        #region Read
        public async Task<List<Domain.Entitys.ImageProduct>> GetImageById(int id)
        {
            return (await unitOfWork.GetRepository<Domain.Entitys.ImageProduct>()
                                    .GetAllAsync(predicate: m => m.Product == id
                                                         && m.ImageRoot != null
                                                         && m.Size != "S220x220"
                                                         && m.IsEnabled == true
                                                         && m.IsCover == false))
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
