using Supplier.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;

namespace Supplier.Infrastructure.Queries
{
    public class SupplierQueries
    {
        private readonly IUnitOfWork<SupplierDBContext> unitOfWork =
                         new UnitOfWork<SupplierDBContext>(new SupplierDBContext());

        public async Task<string> GetNameStore(int id)
        => (await unitOfWork.GetRepository<Domain.Shared.Entitys.Supplier>()
                           .GetFirstOrDefaultAsync(predicate: m => m.Id == id))
           .NameShop;

        public async Task<bool> CheckAnyStoreCreate(string name, string link, decimal phone, string email)
        => await unitOfWork.GetRepository<Domain.Shared.Entitys.Supplier>()
                           .ExistsAsync(m => m.NameShop == name || m.LinkShop == link
                                          || m.NumberPhone == phone || m.Email == email);

        public async Task<Domain.Shared.Entitys.Supplier> CheckAnyStoreCreate(Domain.Shared.Entitys.Supplier input)
        {
            unitOfWork.GetRepository<Domain.Shared.Entitys.Supplier>().Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }

    }
}
