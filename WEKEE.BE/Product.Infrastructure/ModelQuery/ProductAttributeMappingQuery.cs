using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductAttributeMappingQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                     new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductAttributeMapping input)
        {
            unitOfWork.GetRepository<ProductAttributeMapping>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<ProductAttributeMapping> input)
        {
            unitOfWork.GetRepository<ProductAttributeMapping>().Insert(input);
            return unitOfWork.SaveChanges();
        }
    }
}
