using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;

namespace Account.Application.CheckRole
{
    /// <summary>
    /// Kiểm tra Thông tin quyền 
    /// </summary>
    public interface ICheckRole
    {
        /// <summary>
        /// Lấy Danh sách Role account
        /// </summary>
        List<RoleAuthDtos> RoleLst(int idAccount);
        /// <summary>
        /// Lấy Danh sách Role account
        /// </summary>
        Task<List<RoleAuthDtos>> RoleLstAsync(int idAccount);
        /// <summary>
        /// 
        /// </summary>
        bool ListRole(string url, int id_User);
        /// <summary>
        /// Lấy full quyền của tài khoản
        /// </summary>
        List<RoleAuthDtos> RoleDtos(int user_Account_id);
        /// <summary>
        /// Kiểm tra đường dẫn và list Role
        /// </summary>
        bool RoleUrl(string url, List<RoleAuthDtos> roleDtos);
        /// <summary>
        /// 
        /// </summary>
        Task<bool> ListRoleAsync(string url, string SessionAccount);
    }
}
