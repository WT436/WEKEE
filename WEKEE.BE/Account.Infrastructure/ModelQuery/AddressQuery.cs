using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class AddressQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                         new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        #region Kiểm tra dữ liệu

        #endregion

        #region Tạo mới dữ liệu
        public void Insert(Address address)
        {
            unitOfWork.GetRepository<Address>()
                           .Insert(address);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(Address address)
        {
            await unitOfWork.GetRepository<Address>()
                           .InsertAsync(address);
            unitOfWork.SaveChanges();
        }

        public void Update(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Update(address);
            unitOfWork.SaveChanges();
        }

        public async Task Delete(int idAccount)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(await unitOfWork.GetRepository<Address>()
                                              .GetAllAsync(predicate: m => m.UserAccountId == idAccount));
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Lấy dữ liệu
        public async Task<Address> GetUniqueAsync(int id)
            => await unitOfWork.GetRepository<Address>()
                               .GetFirstOrDefaultAsync(predicate: m => m.UserAccountId == id);
        #endregion
    }
}
