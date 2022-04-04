using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductProductTagMappingQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                       new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(ProductProductTagMapping input)
        {
            unitOfWork.GetRepository<ProductProductTagMapping>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }

        public int Insert(List<ProductProductTagMapping> input)
        {
            unitOfWork.GetRepository<ProductProductTagMapping>().Insert(input);
            return unitOfWork.SaveChanges();
        }
    }
}
