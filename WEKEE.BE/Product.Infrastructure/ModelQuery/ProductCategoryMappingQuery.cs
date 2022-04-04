using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductCategoryMappingQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                       new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductCategoryMapping input)
        {
            unitOfWork.GetRepository<ProductCategoryMapping>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<ProductCategoryMapping> input)
        {
            unitOfWork.GetRepository<ProductCategoryMapping>().Insert(input);
            return unitOfWork.SaveChanges();
        }
    }
}
