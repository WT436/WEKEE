using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class FeatureProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                      new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(FeatureProduct input)
        {
            unitOfWork.GetRepository<FeatureProduct>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<FeatureProduct> input)
        {
            unitOfWork.GetRepository<FeatureProduct>().Insert(input);
            return unitOfWork.SaveChanges();
        }
    }
}
