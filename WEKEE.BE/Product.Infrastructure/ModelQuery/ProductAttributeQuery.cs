using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductAttributeQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public Task<bool> CheckNameAndTypeExists(string name, int type)
        => unitOfWork.GetRepository<ProductAttribute>()
                     .ExistsAsync(m => m.Name == name && m.Types == type);

        public int Insert(ProductAttribute input)
        {
            unitOfWork.GetRepository<ProductAttribute>().Insert(input);
            unitOfWork.SaveChanges();
            return 1;
        }

        public ProductAttribute InsertObject(ProductAttribute input)
        {
            unitOfWork.GetRepository<ProductAttribute>().Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }

        public async Task<int> TotalPageCategory()
        => (await unitOfWork.GetRepository<ProductAttribute>()
                            .CountAsync());
    }
}
