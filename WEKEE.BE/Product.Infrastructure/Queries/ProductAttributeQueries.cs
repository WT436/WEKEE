using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;

namespace Product.Infrastructure.Queries
{
    public class ProductAttributeQueries
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                         new UnitOfWork<ProductDBContext>(new ProductDBContext());

    }
}
