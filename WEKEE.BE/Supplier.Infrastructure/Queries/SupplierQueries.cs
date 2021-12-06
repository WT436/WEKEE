using Supplier.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Supplier.Infrastructure.Queries
{
    public class SupplierQueries
    {
        private readonly IUnitOfWork<SupplierDBContext> unitOfWork =
                         new UnitOfWork<SupplierDBContext>(new SupplierDBContext());
        public async Task<Domain.Entitys.Supplier> GetSupplierWithAccountID(int id)
                 => await unitOfWork.GetRepository<Domain.Entitys.Supplier>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.UseAccount == id);

        public async Task<Domain.Entitys.Supplier> CreateSupplier(Domain.Entitys.Supplier supplier)
        {
            await unitOfWork.GetRepository<Domain.Entitys.Supplier>()
                            .InsertAsync(supplier);
            unitOfWork.SaveChanges();
            return supplier;
        }

    }
}
