using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.ForgotPassword
{
    /// <summary>
    /// Quên mật khẩu
    /// </summary>
    public interface IForgotPassword
    {
        /// <summary>
        /// 
        /// </summary>
        bool TokenRequest(ForgotPasswordDtos forgotPasswordDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        Task<bool> TokenRequestAsync(ForgotPasswordDtos forgotPasswordDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        bool CodeRequest(ForgotPasswordDtos forgotPasswordDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        Task<bool> CodeRequestAsync(ForgotPasswordDtos forgotPasswordDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        bool TokenRequestConfirmation(ForgotPasswordConfirmationCodeDtos forgotPasswordConfirmationCodeDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        Task<bool> TokenRequestConfirmationAsync(ForgotPasswordConfirmationCodeDtos forgotPasswordConfirmationCodeDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        bool TokenRequestConfirmationUrl(ForgotPasswordConfirmationTokenDtos forgotPasswordConfirmationTokenDtos, string ip);
        /// <summary>
        /// 
        /// </summary>
        Task<bool> TokenRequestConfirmationUrlAsync(ForgotPasswordConfirmationTokenDtos forgotPasswordConfirmationTokenDtos, string ip);
    }
}
