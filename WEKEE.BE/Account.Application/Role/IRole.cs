using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Account.Application.Role
{
    public interface IRole
    {
        /// <summary>Danh sách Role căn bản</summary>
        Task<PagedListOutput<RoleDto>> ListRoleBasicAsync(SearchOrderPageInput searchOrderPageInput);
        /// <summary>Thêm role </summary>
        Task<int> InsertRoleAsync(RoleDto role);
        ///<summary>Xóa tập thể</summary>
        int RemoveRole(List<int> ids);
        ///<summary>Update</summary>
        int UpdateRole(List<int> ids);
        ///<summary>Update</summary>
        int EditRole(RoleDto role);
    }
}
