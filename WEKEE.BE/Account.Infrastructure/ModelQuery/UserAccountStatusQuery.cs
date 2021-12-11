using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class UserAccountStatusQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<UserAccountStatus> GetStatusWithId(int id)
        {
            return await unitOfWork.GetRepository<UserAccountStatus>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.Id == id);
        }

        #region Tạo mới - Create
        public int Insert(UserAccountStatus userAccountStatus)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Insert(userAccountStatus);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<UserAccountStatus> userAccountStatuss)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Insert(userAccountStatuss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(UserAccountStatus userAccountStatus)
        {
            await unitOfWork.GetRepository<UserAccountStatus>()
                            .InsertAsync(userAccountStatus);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<UserAccountStatus> userAccountStatuss)
        {
            await unitOfWork.GetRepository<UserAccountStatus>()
                            .InsertAsync(userAccountStatuss);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(UserAccountStatus userAccountStatus)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Update(userAccountStatus);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<UserAccountStatus> userAccountStatuss)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Update(userAccountStatuss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(UserAccountStatus userAccountStatus)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Update(userAccountStatus);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<UserAccountStatus> userAccountStatuss)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Update(userAccountStatuss);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(UserAccountStatus userAccountStatus)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Delete(userAccountStatus);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<UserAccountStatus> userAccountStatuss)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Delete(userAccountStatuss);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(UserAccountStatus userAccountStatus)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Delete(userAccountStatus);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<UserAccountStatus> userAccountStatuss)
        {
            unitOfWork.GetRepository<UserAccountStatus>()
                      .Delete(userAccountStatuss);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
