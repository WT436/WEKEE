using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
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

        #region Tạo mới dữ liệu
        public void Insert(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Insert(infomationUser);
            unitOfWork.SaveChanges();
        }
        public async Task InsertAsync(InfomationUser infomationUser)
        {
            await unitOfWork.GetRepository<InfomationUser>()
                            .InsertAsync(infomationUser);
            unitOfWork.SaveChanges();
        }
        public void Update(InfomationUser infomationUser)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Update(infomationUser);
            unitOfWork.SaveChanges();
        }

        public async Task Delete(int idAccount)
        {
            unitOfWork.GetRepository<InfomationUser>()
                      .Delete(await unitOfWork.GetRepository<InfomationUser>()
                                              .GetAllAsync(predicate: m => m.UserAccountId == idAccount));
            unitOfWork.SaveChanges();
        }

        #endregion

        #region Lấy dữ liệu
        public async Task<InfomationUser> GetUniqueAsync(int id)
            => await unitOfWork.GetRepository<InfomationUser>()
                               .GetFirstOrDefaultAsync(predicate: m => m.UserAccountId == id);
        #endregion

    }
}
