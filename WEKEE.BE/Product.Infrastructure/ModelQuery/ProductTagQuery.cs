using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductTagQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductTag input)
        {
            unitOfWork.GetRepository<ProductTag>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public async Task<bool> CheckName(string productTagName)
        => await unitOfWork.GetRepository<ProductTag>()
                           .ExistsAsync(m => m.Name.ToUpper() == productTagName.ToUpper());

        public async Task<int> TotalPageCategory()
        => (await unitOfWork.GetRepository<ProductTag>()
                            .CountAsync());
    }
}
