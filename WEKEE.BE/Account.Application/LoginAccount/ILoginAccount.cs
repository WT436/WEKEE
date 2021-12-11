using Account.Domain.Entitys;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.LoginAccount
{
    /// <summary>
    /// Đăng Nhập
    /// </summary>
    public interface ILoginAccount
    {
        /// <summary>
        /// Lấy thông tin tài khoản theo id
        /// </summary>
        UserLogin getUserAccount(int id);
        /// <summary>
        /// Lấy thông tin tài khoản theo id
        /// </summary>
        Task<UserLogin> getUserAccountAsync(int id);
        UserLogin LoginUserAccount(AuthenticationInput loginDto, string ipUser);
        /// <summary>
        /// Kiểm tra và trả ra tài khoản nếu như thông tin chính xác
        /// </summary>
        Task<UserAccountDtos> LoginUserAccountAsync(AuthenticationInput loginDto, string ipUser);
    }
}
