using Account.Domain.Entitys;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    /// <summary>
    /// Đăng Nhập
    /// </summary>
    public interface ILoginAccount
    {
        /// <summary>
        /// Lấy thông tin tài khoản theo id
        /// </summary>
        UserAccount getUserAccount(int id);
        /// <summary>
        /// Lấy thông tin tài khoản theo id
        /// </summary>
        Task<UserAccount> getUserAccountAsync(int id);
        UserAccount LoginUserAccount(AuthenticationInput loginDto, string ipUser);
        /// <summary>
        /// Kiểm tra và trả ra tài khoản nếu như thông tin chính xác
        /// </summary>
        Task<UserAccountDtos> LoginUserAccountAsync(AuthenticationInput loginDto, string ipUser);
    }
}
