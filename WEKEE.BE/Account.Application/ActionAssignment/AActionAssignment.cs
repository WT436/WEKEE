using Account.Application.Action;
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.ModelQuery;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.ActionAssignment
{
    public class AActionAssignment : IActionAssignment
    {
        private readonly AAction _action = new AAction();
        private readonly ActionQuery _actionQuery = new ActionQuery();
        private readonly PermissionQuery _permissionQuery = new PermissionQuery();
        private readonly ActionAssignmentQuery actionAssignmentQuery = new ActionAssignmentQuery();

       
        public async Task<bool> DeleteAccount(int id_Account)
        {
           
            return true;
        }

        public PagedListOutput<ActionAssignmentDto> ListActionAssignment(int idPermission, PagedListInput pagedListInput)
        {
            //lấy dữ liệu resource,
            var dataAction = _action.ListActionBasic(pagedListInput);
            // lấy dữ liệu action
            var dataActionAssignment = actionAssignmentQuery.ListActionAssignmentWithId(idPermission);
            // map data
            return MapPagedListOutput.MapingpagedListOutput(action: dataAction,
                                                            actionAssignments: dataActionAssignment,
                                                            permissionId: idPermission);
        }

        public void UpdateOrInsert(ActionAssignmentDto actionAssignmentDto)
        {
            // kieemr tra 
            if (_actionQuery.CountId(actionAssignmentDto.Id) != 1)
            {
                throw new ClientException(400, "Action already exists!");
            }

            if (_permissionQuery.CountId(actionAssignmentDto.PermissionId) != 1)
            {
                throw new ClientException(400, "Permission already exists!");
            }

            var dataResourceAction = actionAssignmentQuery.CheckExistsUnique(actionId: actionAssignmentDto.Id, permissionId: actionAssignmentDto.PermissionId);
            if (dataResourceAction == null)
            {
                actionAssignmentQuery.Insert(new Account.Domain.Entitys.ActionAssignment
                {
                    ActionId = actionAssignmentDto.Id,
                    PermissionId = actionAssignmentDto.PermissionId,
                    IsActive = true
                });
            }
            else
            {
                dataResourceAction.IsActive = !dataResourceAction.IsActive;

                actionAssignmentQuery.Update(dataResourceAction);
            }
        }
    }
}
