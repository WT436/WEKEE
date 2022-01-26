using Account.Domain.Shared.Entitys;
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


        #region Lấy dữ liệu
        public List<ResourceAction> GetDataWithIdAction(int id)
        => unitOfWork.GetRepository<ResourceAction>()
                     .GetAll(predicate: m => m.ActionId == id && m.IsActive == true).ToList();
        public async Task<IList<ResourceAction>> GetDataWithIdResource(int id)
        => await unitOfWork.GetRepository<ResourceAction>()
                           .GetAllAsync(predicate: m => m.ResourceId == id);
        public async Task<IList<ResourceAction>> GetAllActive()
        => await unitOfWork.GetRepository<ResourceAction>()
                           .GetAllAsync(m => m.IsActive == true);
        #endregion

        #region Check bản ghi
        public async Task<ResourceAction> CheckExistsUniqueAsync(int resourceId, int actionId)
        => await unitOfWork.GetRepository<ResourceAction>()
                     .GetFirstOrDefaultAsync(predicate: m => m.ActionId == actionId
                                                          && m.ResourceId == resourceId);
        #endregion

        #region Tạo mới - Create
        public int Insert(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Insert(resourceAction);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<ResourceAction> resourceActions)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Insert(resourceActions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(ResourceAction resourceAction)
        {
            await unitOfWork.GetRepository<ResourceAction>()
                            .InsertAsync(resourceAction);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<ResourceAction> resourceActions)
        {
            await unitOfWork.GetRepository<ResourceAction>()
                            .InsertAsync(resourceActions);
            return await unitOfWork.SaveChangesAsync(unitOfWorks: unitOfWork);
        }
        #endregion

        #region Cập nhật - Update
        public int Update(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Update(resourceAction);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<ResourceAction> resourceActions)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Update(resourceActions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Update(resourceAction);
            return await unitOfWork.SaveChangesAsync(unitOfWorks: unitOfWork);
        }
        public async Task<int> UpdateAsync(List<ResourceAction> resourceActions)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Update(resourceActions);
            return await unitOfWork.SaveChangesAsync(unitOfWorks: unitOfWork);
        }
        #endregion

        #region Xóa - Delete
        public int Delete(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Delete(resourceAction);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<ResourceAction> resourceActions)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Delete(resourceActions);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(ResourceAction resourceAction)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Delete(resourceAction);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<ResourceAction> resourceActions)
        {
            unitOfWork.GetRepository<ResourceAction>()
                      .Delete(resourceActions);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
