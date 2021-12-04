using Account.Domain.Entitys;
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
        public async Task<IList<UserAccountIp>> GetListIpWithAccountAsync(int ipUser)
            => await unitOfWork.GetRepository<UserAccountIp>().GetAllAsync(m => m.IpUserAccount == ipUser);
        /// <summary>
        /// lấy tất cả thông tin ip của id user
        /// </summary>
        public IList<UserAccountIp> GetListIpWithAccount(int ipUser)
            =>  unitOfWork.GetRepository<UserAccountIp>().GetAll(m => m.IpUserAccount == ipUser).ToList();

        public async Task CreateUserAccountIp(int AccountId, string ip, string userAgent)
        {
            await unitOfWork.GetRepository<UserAccountIp>()
                               .InsertAsync(new UserAccountIp
                               {
                                   Ip = ip,
                                   UserAgent = userAgent,
                                   IpUserAccount = AccountId,
                                   DateUpdate = DateTime.Now,
                                   DateCreate = DateTime.Now,
                                   UpdateCount = 0
                               });
            unitOfWork.SaveChanges();
        }

        public async Task Delete(int idAccount)
        {
            unitOfWork.GetRepository<UserAccountIp>()
                      .Delete(await unitOfWork.GetRepository<UserAccountIp>()
                                              .GetAllAsync(predicate: m => m.IpUserAccount == idAccount));
            unitOfWork.SaveChanges();
        }

    }
}
