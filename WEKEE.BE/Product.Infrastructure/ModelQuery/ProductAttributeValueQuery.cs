using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductAttributeValueQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductAttributeValue input)
        {
            unitOfWork.GetRepository<ProductAttributeValue>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<ProductAttributeValue> inputs)
        {
            unitOfWork.GetRepository<ProductAttributeValue>().Insert(inputs);
            return unitOfWork.SaveChanges();
        }
    }
}
