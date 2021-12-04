using Account.Domain.Entitys;
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

        public async Task<IList<PermissionAssignment>> GetAllActive()
                     => await unitOfWork.GetRepository<PermissionAssignment>().GetAllAsync(m => m.IsActive == true);


        #region Lấy dữ liệu

        public List<PermissionAssignment> ListPermissionAssignmentWithId(int id)
          => unitOfWork.GetRepository<PermissionAssignment>().GetAll(predicate: m => m.RoleId == id && m.IsActive == true).ToList();

        #endregion

        #region Tạo mới bản ghi
        public void InsertUnique(PermissionAssignment  permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>().Insert(permissionAssignment);
            unitOfWork.SaveChanges();
        }

        public async Task InsertUniqueAsync(PermissionAssignment  permissionAssignment)
        {
            await unitOfWork.GetRepository<PermissionAssignment>().InsertAsync(permissionAssignment);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Update bản ghi
        public void UpdateActiveUnique(PermissionAssignment  permissionAssignment)
        {
            unitOfWork.GetRepository<PermissionAssignment>().Update(permissionAssignment);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Check bản ghi
        public PermissionAssignment CheckExistsUnique(int roleId, int permissionId)
                              => unitOfWork.GetRepository<PermissionAssignment>()
                                           .GetFirstOrDefault(predicate: m => m.PermissionId == permissionId
                                                                           && m.RoleId == roleId);
        #endregion
    }
}
