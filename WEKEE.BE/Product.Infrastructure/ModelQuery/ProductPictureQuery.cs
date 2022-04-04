using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductPictureQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductPictureMapping input)
        {
            unitOfWork.GetRepository<ProductPictureMapping>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<ProductPictureMapping> input)
        {
            unitOfWork.GetRepository<ProductPictureMapping>().Insert(input);
            return unitOfWork.SaveChanges();
        }
    }
}
