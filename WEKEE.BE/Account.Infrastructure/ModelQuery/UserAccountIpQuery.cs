using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class UserAccountIpQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                  new UnitOfWork<AuthorizationContext>(new AuthorizationContext());
        /// <summary>
        /// lấy tất cả thông tin ip của id user dạng bất đồng bộ 
        /// </summary>
        public async Task<IList<UserAccountIp>> GetListIpWithAccountAsync(int id)
            => await unitOfWork.GetRepository<UserAccountIp>().GetAllAsync(m => m.AccountId == id);
        /// <summary>
        /// lấy tất cả thông tin ip của id user
        /// </summary>
        public IList<UserAccountIp> GetListIpWithAccount(int id)
            =>  unitOfWork.GetRepository<UserAccountIp>().GetAll(m => m.AccountId == id).ToList();

        #region Tạo mới - Create
        public int Insert(UserAccountIp userAccountIp)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Insert(userAccountIp);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<UserAccountIp> userAccountIps)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Insert(userAccountIps);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(UserAccountIp userAccountIp)
        {
            await unitOfWork.GetRepository<UserAccountIp>()
                            .InsertAsync(userAccountIp);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<UserAccountIp> userAccountIps)
        {
            await unitOfWork.GetRepository<UserAccountIp>()
                            .InsertAsync(userAccountIps);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(UserAccountIp userAccountIp)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Update(userAccountIp);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<UserAccountIp> userAccountIps)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Update(userAccountIps);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(UserAccountIp userAccountIp)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Update(userAccountIp);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<UserAccountIp> userAccountIps)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Update(userAccountIps);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(UserAccountIp userAccountIp)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Delete(userAccountIp);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<UserAccountIp> userAccountIps)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Delete(userAccountIps);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(UserAccountIp userAccountIp)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Delete(userAccountIp);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<UserAccountIp> userAccountIps)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Delete(userAccountIps);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
