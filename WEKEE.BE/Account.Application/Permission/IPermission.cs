using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;

namespace Account.Application.Permission
{
    /// <summary>Thao tác với bảng Permission</summary>
    public interface IPermission
    {
        /// <summary>Danh sách Permission căn bản</summary>
        PagedListOutput<PermissionDto> ListPermissionBasic(PagedListInput pagedListInput);
        /// <summary>Danh sách Permission căn bản</summary>
        Task<PagedListOutput<PermissionDto>> ListPermissionBasicAsync(PagedListInput pagedListInput);
        /// <summary>Danh sách Permission thứ tự tăng dần.</summary>
        PagedListOutput<PermissionDto> ListOrderByAscPermission(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Permission thứ tự tăng dần.</summary>
        Task<PagedListOutput<PermissionDto>> ListOrderByAscPermissionAsync(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Permission Thứ tự giảm dần.</summary>
        PagedListOutput<PermissionDto> ListOrderByDescPermission(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Permission Thứ tự giảm dần.</summary>
        Task<PagedListOutput<PermissionDto>> ListOrderByDescPermissionAsync(OrderByPageListInput orderByPageListInput);
        ///<summary>Thêm Permission </summary>
        void InsertPermission(PermissionDto permission);
        ///<summary>Thêm Permission </summary>
        Task InsertPermissionAsync(PermissionDto permission);
        ///<summary>Xóa tập thể</summary>
        int RemovePermission(List<int> ids);
        ///<summary>Xóa tập thể</summary>
        Task<int> RemovePermissionAsync(List<int> ids);
        ///<summary>Update</summary>
        int UpdatePermission(List<int> ids);
        ///<summary>Update</summary>
        int UpdatePermissionAsync(List<int> ids);
        ///<summary>Update</summary>
        int EditPermission(PermissionDto permission);
        ///<summary>Update</summary>
        int EditPermissionAsync(PermissionDto permission);
    }
}
