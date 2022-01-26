
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.ChangePassword;

namespace Account.API.Src.AccountAreas
{
    public class ChangePasswordController : Controller
    {
        private readonly IChangePassword _changePassword;
        public ChangePasswordController(IChangePassword changePassword)
        {
            _changePassword = changePassword;
        }

        [Route(LoginRouter.ChangePassword)]
        [HttpPatch]
        public IActionResult WatchChangePassword()
        {
            return Ok();
        }

        [Route(LoginRouter.ChangePassword)]
        [HttpPut]
        public IActionResult ChangePassword(AuthenticationInput loginDtos, string passwordNew)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            _changePassword.DefaultChangPass(loginDtos, passwordNew, ip);
            return StatusCode(405, "fsjkdlafsdas");
        }
    }
}
