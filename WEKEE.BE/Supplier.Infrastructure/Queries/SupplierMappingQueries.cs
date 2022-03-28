using Supplier.Domain.Shared.Entitys;
using Supplier.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Supplier.Infrastructure.Queries
{
    public class SupplierMappingQueries
    {
        private readonly IUnitOfWork<SupplierDBContext> unitOfWork =
                        new UnitOfWork<SupplierDBContext>(new SupplierDBContext());

        public async Task<IList<SupplierMapping>> MappingStoreByIdStaff(int idAccount)
        => await unitOfWork.GetRepository<SupplierMapping>()
                           .GetAllAsync(predicate: m => m.UseAccount == idAccount);

        public async Task<bool> CheckStoreByBoss(int idAccount)
        => await unitOfWork.GetRepository<SupplierMapping>()
                           .ExistsAsync(m => m.UseAccount == idAccount && m.IsBoss == true);

        public async Task<SupplierMapping> CreateMapping(SupplierMapping input)
        {
            unitOfWork.GetRepository<SupplierMapping>().Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }
    }
}
