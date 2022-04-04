using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class SeoProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(Seo input)
        {
            unitOfWork.GetRepository<Seo>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }
    }
}
