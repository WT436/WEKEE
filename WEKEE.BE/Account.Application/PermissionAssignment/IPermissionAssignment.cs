using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Account.Application.PermissionAssignment
{
    public interface IPermissionAssignment
    {
        public PagedListOutput<PermissionAssignmentDto> PermissionAssignmentDto(int idRole, PagedListInput pagedListInput);

        public void UpdateOrInsert(PermissionAssignmentDto permissionAssignmentDto);
    }
}
