using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class ActionAssignmentQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                         new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<ActionAssignment>> GetAllActive()
                     => await unitOfWork.GetRepository<ActionAssignment>()
                                        .GetAllAsync(m => m.IsActive == true);

        #region Kiểm Tra - Check
        public ActionAssignment CheckExistsUnique(int actionId, int permissionId)
               => unitOfWork.GetRepository<ActionAssignment>()
                            .GetFirstOrDefault(predicate: m => m.PermissionId == permissionId
                                                            && m.ActionId == actionId);
        #endregion

        #region Truy xuất - Read
        public List<ActionAssignment> ListActionAssignmentWithId(int id)
               => unitOfWork.GetRepository<ActionAssignment>()
                            .GetAll(predicate: m => m.PermissionId == id
                                                 && m.IsActive == true).ToList();
        #endregion

        #region Tạo mới - Create
        public int Insert(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Insert(actionAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<ActionAssignment> actionAssignments)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Insert(actionAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(ActionAssignment actionAssignment)
        {
            await unitOfWork.GetRepository<ActionAssignment>()
                            .InsertAsync(actionAssignment);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<ActionAssignment> actionAssignments)
        {
            await unitOfWork.GetRepository<ActionAssignment>()
                            .InsertAsync(actionAssignments);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public void Update(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Update(actionAssignment);
            unitOfWork.SaveChanges();
        }
        public void Update(List<ActionAssignment> actionAssignments)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Update(actionAssignments);
            unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Update(actionAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<ActionAssignment> actionAssignments)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Update(actionAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public void Delete(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(actionAssignment);
            unitOfWork.SaveChanges();
        }
        public void Delete(List<ActionAssignment> actionAssignments)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(actionAssignments);
            unitOfWork.SaveChanges();
        }

        public int Delete(int id)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(id);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(ids);
            return unitOfWork.SaveChanges();
        }

        public async Task<int> DeleteAsync(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(actionAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<ActionAssignment> actionAssignments)
        {
            unitOfWork.GetRepository<ActionAssignment>()
                      .Delete(actionAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
