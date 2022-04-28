using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IRoleAdmin
    {
        Task<PagedListOutput<RoleReadDto>> GetRolePageList(SearchOrderPageInput input);
        Task<int> DeleteRole(List<int> ids);
        Task<int> EditUnitRole(RoleLstChangeDto input);
        Task<int> InsertOrUpdateRole(RoleReadDto input, int idAccount);
    }
}
