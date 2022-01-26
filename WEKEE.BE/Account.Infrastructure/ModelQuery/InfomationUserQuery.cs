using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class InfomationUserQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                        new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        #region Kiểm tra dữ liệu

        #endregion

        #region Lấy dữ liệu
        public async Task<InfomationUser> GetUniqueAsync(int id)
            => await unitOfWork.GetRepository<InfomationUser>()
                               .GetFirstOrDefaultAsync(predicate: m => m.AccountId == id);
        #endregion


        #region Tạo mới - Create
        public int Insert(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Insert(infomationUser);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<InfomationUser> infomationUsers)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Insert(infomationUsers);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(InfomationUser infomationUser)
        {
            await unitOfWork.GetRepository<InfomationUser>()
                            .InsertAsync(infomationUser);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<InfomationUser> infomationUsers)
        {
            await unitOfWork.GetRepository<InfomationUser>()
                            .InsertAsync(infomationUsers);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Update(infomationUser);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<InfomationUser> infomationUsers)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Update(infomationUsers);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Update(infomationUser);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<InfomationUser> infomationUsers)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Update(infomationUsers);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Delete(infomationUser);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<InfomationUser> infomationUsers)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Delete(infomationUsers);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Delete(infomationUser);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<InfomationUser> infomationUsers)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Delete(infomationUsers);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
