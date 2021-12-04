using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class ResourceActionQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<ResourceAction>> GetAllActive()
                     => await unitOfWork.GetRepository<ResourceAction>().GetAllAsync(m => m.IsActive == true);

        #region Lấy dữ liệu

        public List<ResourceAction> ListResourceActionWithId(int id)
          => unitOfWork.GetRepository<ResourceAction>().GetAll(predicate: m => m.ActionId == id && m.IsActive == true).ToList();

        #endregion

        #region Tạo mới bản ghi
        public void InsertUnique(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>().Insert(resourceAction);
            unitOfWork.SaveChanges();
        }

        public async Task InsertUniqueAsync(ResourceAction resourceAction)
        {
            await unitOfWork.GetRepository<ResourceAction>().InsertAsync(resourceAction);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Update bản ghi
        public void UpdateActiveUnique(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>().Update(resourceAction);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Check bản ghi
        public ResourceAction CheckExistsUnique(int resourceId, int actionId)
                              => unitOfWork.GetRepository<ResourceAction>()
                                           .GetFirstOrDefault(predicate: m => m.ActionId == actionId
                                                                           && m.ResourceId == resourceId);
        #endregion
    }
}
