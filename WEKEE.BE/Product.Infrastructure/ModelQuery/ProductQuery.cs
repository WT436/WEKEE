using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(Domain.Shared.Entitys.Product input)
        {
            unitOfWork.GetRepository<Domain.Shared.Entitys.Product>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }
        public Domain.Shared.Entitys.Product InsertObject(Domain.Shared.Entitys.Product input)
        {
            unitOfWork.GetRepository<Domain.Shared.Entitys.Product>().Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }
    }
}
