using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface IPermissionAssignment
    {
        public PagedListOutput<PermissionAssignmentDto> PermissionAssignmentDto(int idRole, PagedListInput pagedListInput);

        public void UpdateOrInsert(PermissionAssignmentDto permissionAssignmentDto);
    }
}
