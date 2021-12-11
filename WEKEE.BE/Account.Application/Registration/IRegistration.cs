using System.Threading.Tasks;
using Account.Domain.Dto;

namespace Account.Application.Registration
{
    /// <summary>
    /// Đăng Ký
    /// </summary>
    public interface IRegistration
    {
        string CreateAccount(AccountDtos accountDto, string ipUser, string userAgent);
        Task<string> CreateAccountAsync(AccountDtos accountDto, string ipUser, string userAgent);
    }
}
