using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class UserAccountStatusQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<int> Create()
        {
            var userAccoutStatus = new UserAccountStatus();
            await unitOfWork.GetRepository<UserAccountStatus>().InsertAsync(userAccoutStatus);
            unitOfWork.SaveChanges();
            return userAccoutStatus.Id;
        }

        public async Task<UserAccountStatus> GetStatusWithId(int id)
        {
            return await unitOfWork.GetRepository<UserAccountStatus>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.Id == id);
        }
    }
}
