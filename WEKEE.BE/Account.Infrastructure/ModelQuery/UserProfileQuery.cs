using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class UserProfileQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<UserProfile> GetUniqueId(int idUser)
            => await unitOfWork.GetRepository<UserProfile>().GetFirstOrDefaultAsync(predicate: m => m.Id == idUser);
       
        #region Tạo mới - Create
        public int Insert(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Insert(userProfile);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<UserProfile> userProfiles)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Insert(userProfiles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(UserProfile userProfile)
        {
            await unitOfWork.GetRepository<UserProfile>()
                            .InsertAsync(userProfile);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<UserProfile> userProfiles)
        {
            await unitOfWork.GetRepository<UserProfile>()
                            .InsertAsync(userProfiles);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Update(userProfile);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<UserProfile> userProfiles)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Update(userProfiles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Update(userProfile);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<UserProfile> userProfiles)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Update(userProfiles);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Delete(userProfile);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<UserProfile> userProfiles)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Delete(userProfiles);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Delete(userProfile);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<UserProfile> userProfiles)
        {
            unitOfWork.GetRepository<UserProfile>()
                      .Delete(userProfiles);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
