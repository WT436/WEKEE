using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class ChangePasswordController : Controller
    {
        private readonly IChangePassword _changePassword;
        public ChangePasswordController(IChangePassword changePassword)
        {
            _changePassword = changePassword;
        }

        [Route(LoginRouter.ChangePassword.WATCH)]
        [HttpGet]
        public IActionResult WatchChangePassword()
        {
            return Ok();
        }

        [Route(LoginRouter.ChangePassword.UPDATE)]
        [HttpPost]
        public IActionResult ChangePassword(AuthenticationInput loginDtos, string passwordNew)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            _changePassword.DefaultChangPass(loginDtos, passwordNew, ip);
            return StatusCode(405, "fsjkdlafsdas");
        }
    }
}
