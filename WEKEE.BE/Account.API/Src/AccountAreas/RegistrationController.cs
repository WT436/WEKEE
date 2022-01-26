
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Registration;

namespace Account.API.Src.AccountAreas
{
    public class RegistrationController : Controller
    {
        private readonly IRegistration _registration;
        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }

        [Route(LoginRouter.Registration)]
        [HttpPost]
        public async Task<IActionResult> Registration(AccountDtos accountDtos)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
            await _registration.CreateAccountAsync(accountDtos, ip, userAgent);
            return Ok("Tài khoản đã được khởi tạo. Chúng tôi đã gửi một đường dẫn và mã kích hoạt đến Email của bạn!");
        }
    }
}
