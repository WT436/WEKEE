using Microsoft.EntityFrameworkCore;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class SpecificationAttributeQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public async Task<SpecificationAttribute> GetIdByGroupAndKey(string group, string key)
        => await unitOfWork.GetRepository<SpecificationAttribute>()
                           .GetFirstOrDefaultAsync(predicate: m => m.Key == key && m.GroupSpecification == group);

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

        public async Task<List<string>> GetAllNameGroupSpec(List<int> category)
        => await unitOfWork.GetRepository<SpecificationAttribute>()
                           .GetAll(m => category.Contains(m.CategoryProductId) && m.GroupSpecification != null)
                           .Select(n => n.GroupSpecification)
                           .Distinct()
                           .ToListAsync();

        public async Task<List<string>> GetAllKeyByGroupSpec(List<int> category, string nameGroup)
        {
            if (nameGroup == null)
            {
                return await unitOfWork.GetRepository<SpecificationAttribute>()
                       .GetAll(m => category.Contains(m.CategoryProductId) && m.GroupSpecification == null)
                       .Select(n => n.Key)
                       .Distinct()
                       .ToListAsync();
            }
            else
            {
                return await unitOfWork.GetRepository<SpecificationAttribute>()
                       .GetAll(m => category.Contains(m.CategoryProductId) && m.GroupSpecification.ToUpper() == nameGroup.ToUpper())
                       .Select(n => n.Key)
                       .Distinct()
                       .ToListAsync();
            }
        }
    }
}
