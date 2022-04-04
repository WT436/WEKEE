using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ImageProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int InsertImageProductOutId(ImageProduct input)
        {
            unitOfWork.GetRepository<ImageProduct>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int InsertImageProductOutId(List<ImageProduct> inputs)
        {
            unitOfWork.GetRepository<ImageProduct>().Insert(inputs);
            return unitOfWork.SaveChanges();
        }
    }
}
