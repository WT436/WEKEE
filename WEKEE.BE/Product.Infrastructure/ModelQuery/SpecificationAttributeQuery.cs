using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class SpecificationAttributeQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<bool> CheckCategoryAndGroupAndKey(int idCategory, string group, string key)
        => await unitOfWork.GetRepository<SpecificationAttribute>()
                           .ExistsAsync(m => m.CategoryProductId == idCategory
                                          && m.GroupSpecification.ToUpper() == group.ToUpper()
                                          && m.Key.ToUpper() == key.ToUpper());

        public SpecificationAttribute Insert(SpecificationAttribute input)
        {
            unitOfWork.GetRepository<SpecificationAttribute>()
                      .Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }

        public async Task<int> TotalPageCategory()
        => (await unitOfWork.GetRepository<SpecificationAttribute>()
                            .CountAsync());
    }
}
