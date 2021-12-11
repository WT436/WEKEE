using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;

namespace Account.Application.PermissionAssignment
{
    public interface IPermissionAssignment
    {
        public PagedListOutput<PermissionAssignmentDto> PermissionAssignmentDto(int idRole, PagedListInput pagedListInput);

        public void UpdateOrInsert(PermissionAssignmentDto permissionAssignmentDto);
    }
}
