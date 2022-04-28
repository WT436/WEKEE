using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IPermissionAdmin
    {
        Task<PagedListOutput<PermissionReadDto>> GetPermissionPageList(SearchOrderPageInput input);
        Task<int> DeletePermission(List<int> ids);
        Task<int> EditUnitPermission(PermissionLstChangeDto input);
        Task<int> InsertOrUpdatePermission(PermissionReadDto input, int idAccount);
        Task<List<PermissionSummaryReadDto>> GetSummaryPermission(SearchTextInput input);
    }
}
