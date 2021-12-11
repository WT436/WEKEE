using Account.Domain.Entitys;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using Utils.Auth.Dtos;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.ProcessAccount
{
    /// <summary>
    /// Sứ lý vấn đề về tài khoản
    /// </summary>
    public interface IProcessAccount
    {
        /// <summary>
        /// Kiểm tra xem có user nào phù hợp với 2 yêu cầu này không?
        /// </summary>
        Task<UserLogin> ProcessTokenAsync(StringValues token, string ip);
        /// <summary>
        /// 
        /// </summary>
        JwtCustomClaims ProcessToken(string token);
        /// <summary>
        /// Tạo Token cho Account
        /// </summary>
        JwtResponse CreateToken(UserAccountDtos userAccount, string ip);
        /// <summary>
        /// Tạo Token cho Account
        /// </summary>
        Task<JwtResponse> CreateTokenAsync(UserLogin userAccount, string ip);
        /// <summary>
        /// so sánh session và cookie
        /// </summary>
        bool CompareSessionCookie(JwtCustomClaims jwtCustomClaims, SessionCustom sessionCustom, string Ip);

        /// <summary>
        /// so sánh session và cookie bất đồng bộ
        /// </summary>
        Task<bool> CompareSessionCookieAsync(JwtCustomClaims jwtCustomClaims, SessionCustom sessionCustom, string Ip);
        /// <summary>
        /// Lấy tên tài khoản
        /// </summary>
        public Task<string> GetNameAccount(int id);
    }
}
