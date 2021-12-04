using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class UserProfileQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<int> CreateDefault(UserProfile user_profile)
        {
            await unitOfWork.GetRepository<UserProfile>().InsertAsync(user_profile);
            unitOfWork.SaveChanges();
            return user_profile.Id;
        }
        public async Task<UserProfile> GetUniqueId(int idUser)
            => await unitOfWork.GetRepository<UserProfile>().GetFirstOrDefaultAsync(predicate: m => m.Id == idUser);
        public int UpdateDefault(UserProfile user_profile)
        {
            unitOfWork.GetRepository<UserProfile>().Update(user_profile);
            unitOfWork.SaveChanges();
            return user_profile.Id;
        }
        public async Task Delete(int id)
        {
            unitOfWork.GetRepository<UserProfile>().Delete(id: id);
            unitOfWork.SaveChanges();
        }
    }
}
