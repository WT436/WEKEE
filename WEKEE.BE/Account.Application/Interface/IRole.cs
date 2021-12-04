using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface IRole
    {
        /// <summary>Danh sách Role căn bản</summary>
        PagedListOutput<RoleDto> ListRoleBasic(PagedListInput pagedListInput);
        /// <summary>Danh sách Role căn bản</summary>
        Task<PagedListOutput<RoleDto>> ListRoleBasicAsync(PagedListInput pagedListInput);
        /// <summary>Danh sách Role thứ tự tăng dần.</summary>
        PagedListOutput<RoleDto> ListOrderByAscRole(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Role thứ tự tăng dần.</summary>
        Task<PagedListOutput<RoleDto>> ListOrderByAscRoleAsync(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Role Thứ tự giảm dần.</summary>
        PagedListOutput<RoleDto> ListOrderByDescRole(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Role Thứ tự giảm dần.</summary>
        Task<PagedListOutput<RoleDto>> ListOrderByDescRoleAsync(OrderByPageListInput orderByPageListInput);
        ///<summary>Thêm Role </summary>
        void InsertRole(RoleDto  roleDto);
        ///<summary>Thêm Role </summary>
        Task InsertRoleAsync(RoleDto  roleDto);
        ///<summary>Xóa tập thể</summary>
        int RemoveRole(List<int> ids);
        ///<summary>Xóa tập thể</summary>
        Task<int> RemoveRoleAsync(List<int> ids);
        ///<summary>Update</summary>
        int UpdateRole(List<int> ids);
        ///<summary>Update</summary>
        int UpdateRoleAsync(List<int> ids);
        ///<summary>Update</summary>
        int EditRole(RoleDto  roleDto);
        ///<summary>Update</summary>
        int EditRoleAsync(RoleDto  roleDto);
    }
}
