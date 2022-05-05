using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class UserProfileEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                     new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<bool> CheckEmailNumberPhoneUserName(string userName, string email, string numberPhone)
        {
            if (email == null && numberPhone != null)
            {
                return await unitOfWork.GetRepository<UserProfile>()
                                       .ExistsAsync(m => m.UserName == userName
                                                      || m.NumberPhone == numberPhone);
            }
            else if (email != null && numberPhone == null)
            {
                return await unitOfWork.GetRepository<UserProfile>()
                                       .ExistsAsync(m => m.UserName == userName
                                                      || m.Email == email);
            }
            else
            {
                return await unitOfWork.GetRepository<UserProfile>()
                                       .ExistsAsync(m => m.UserName == userName
                                                      || m.Email == email
                                                      || m.NumberPhone == numberPhone);
            }
        }

        public async Task<int> Insert(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>().Insert(userProfile);
            return unitOfWork.SaveChanges();
        }

        public async Task<int> Update(UserProfile userProfile)
        {
            unitOfWork.GetRepository<UserProfile>().Update(userProfile);
            return unitOfWork.SaveChanges();
        }
    }
}
