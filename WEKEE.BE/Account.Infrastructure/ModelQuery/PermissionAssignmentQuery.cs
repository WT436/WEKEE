using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class PermissionAssignmentQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        
        #region Lấy dữ liệu
        public List<PermissionAssignment> ListPermissionAssignmentWithId(int id)
          => unitOfWork.GetRepository<PermissionAssignment>()
                       .GetAll(predicate: m => m.RoleId == id && m.IsActive == true).ToList();
        public async Task<IList<PermissionAssignment>> GetAllActive()
                     => await unitOfWork.GetRepository<PermissionAssignment>()
                                        .GetAllAsync(m => m.IsActive == true);
        #endregion

        #region Check bản ghi
        public PermissionAssignment CheckExistsUnique(int roleId, int permissionId)
                              => unitOfWork.GetRepository<PermissionAssignment>()
                                           .GetFirstOrDefault(predicate: m => m.PermissionId == permissionId
                                                                           && m.RoleId == roleId);
        #endregion

        #region Tạo mới - Create
        public int Insert(PermissionAssignment permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Insert(permissionAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<PermissionAssignment> permissionAssignments)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Insert(permissionAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(PermissionAssignment permissionAssignment)
        {
            await unitOfWork.GetRepository<PermissionAssignment>()
                            .InsertAsync(permissionAssignment);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<PermissionAssignment> permissionAssignments)
        {
            await unitOfWork.GetRepository<PermissionAssignment>()
                            .InsertAsync(permissionAssignments);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(PermissionAssignment permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Update(permissionAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<PermissionAssignment> permissionAssignments)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Update(permissionAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(PermissionAssignment permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Update(permissionAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<PermissionAssignment> permissionAssignments)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Update(permissionAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(PermissionAssignment permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Delete(permissionAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<PermissionAssignment> permissionAssignments)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Delete(permissionAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(PermissionAssignment permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Delete(permissionAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<PermissionAssignment> permissionAssignments)
        {
            unitOfWork.GetRepository<PermissionAssignment>()
                      .Delete(permissionAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
