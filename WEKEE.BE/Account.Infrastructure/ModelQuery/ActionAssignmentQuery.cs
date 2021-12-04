using Account.Domain.Entitys;
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
                     => await unitOfWork.GetRepository<ActionAssignment>().GetAllAsync(m => m.IsActive == true);


        #region Lấy dữ liệu
        public List<ActionAssignment> ListActionAssignmentWithId(int id)
          => unitOfWork.GetRepository<ActionAssignment>().GetAll(predicate: m => m.PermissionId == id && m.IsActive == true).ToList();

        #endregion

        #region Tạo mới bản ghi
        public void InsertUnique(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>().Insert(actionAssignment);
            unitOfWork.SaveChanges();
        }

        public async Task InsertUniqueAsync(ActionAssignment actionAssignment)
        {
            await unitOfWork.GetRepository<ActionAssignment>().InsertAsync(actionAssignment);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Update bản ghi
        public void UpdateActiveUnique(ActionAssignment actionAssignment)
        {
            unitOfWork.GetRepository<ActionAssignment>().Update(actionAssignment);
            unitOfWork.SaveChanges();
        }
        #endregion

        #region Check bản ghi
        public ActionAssignment CheckExistsUnique(int actionId, int permissionId)
                              => unitOfWork.GetRepository<ActionAssignment>()
                                           .GetFirstOrDefault(predicate: m => m.PermissionId == permissionId
                                                                           && m.ActionId == actionId);
        #endregion


    }
}
