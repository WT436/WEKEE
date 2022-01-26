using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
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

        #region Lấy dữ liệu
        public async Task<Address> GetUniqueAsync(int id)
            => await unitOfWork.GetRepository<Address>()
                               .GetFirstOrDefaultAsync(predicate: m => m.AccountId == id);
        #endregion

        #region Tạo mới - Create
        public int Insert(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Insert(address);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Address> addresss)
        {
            unitOfWork.GetRepository<Address>()
                      .Insert(addresss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Address address)
        {
            await unitOfWork.GetRepository<Address>()
                            .InsertAsync(address);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Address> addresss)
        {
            await unitOfWork.GetRepository<Address>()
                            .InsertAsync(addresss);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Update(address);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Address> addresss)
        {
            unitOfWork.GetRepository<Address>()
                      .Update(addresss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Update(address);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Address> addresss)
        {
            unitOfWork.GetRepository<Address>()
                      .Update(addresss);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(id);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(ids);
            return unitOfWork.SaveChanges();
        }

        public int Delete(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(address);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Address> addresss)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(addresss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Address address)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(address);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Address> addresss)
        {
            unitOfWork.GetRepository<Address>()
                      .Delete(addresss);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

    }
}
