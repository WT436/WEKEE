using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());
        #region Create
        public async Task<Domain.Entitys.Product> Create(Domain.Entitys.Product product)
        {
            await unitOfWork.GetRepository<Domain.Entitys.Product>().InsertAsync(product);
            unitOfWork.SaveChanges();
            return product;
        }
        #endregion

        #region Read
        public List<string> GetAllAlbum(int idSupplier)
                         => unitOfWork.GetRepository<Domain.Entitys.Product>()
                                      .GetAll()
                                      .Where(m => m.Supplier == idSupplier)
                                      .Select(m => m.ProductAlbum).Distinct().ToList();

        public async Task<Domain.Entitys.Product> GetUnitProduct(int id)
                  => await unitOfWork.GetRepository<Domain.Entitys.Product>()
                                     .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public async Task<bool> CheckIdProduct(int id)
                 => await unitOfWork.GetRepository<Domain.Entitys.Product>()
                                    .ExistsAsync(m => m.Id == id && m.IsEnabled == true);

        #endregion

        #region Update
        #endregion

        #region  Delete
        #endregion

        #region  Join
        #endregion
    }
}
