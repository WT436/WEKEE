using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Account.Application.Permission
{
    /// <summary>Thao tác với bảng Permission</summary>
    public interface IPermission
    {
        /// <summary>Danh sách Permission căn bản</summary>
        Task<PagedListOutput<PermissionDto>> ListPermissionBasicAsync(SearchOrderPageInput searchOrderPageInput);
        /// <summary>Thêm permission </summary>
        Task<int> InsertPermissionAsync(PermissionDto permission);
        ///<summary>Xóa tập thể</summary>
        int RemovePermission(List<int> ids);
        ///<summary>Update</summary>
        int UpdatePermission(List<int> ids);
        ///<summary>Update</summary>
        int EditPermission(PermissionDto permission);
    }
}
