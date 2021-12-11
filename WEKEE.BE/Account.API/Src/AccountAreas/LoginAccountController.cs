
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.LoginAccount;
using Account.Application.CheckRole;
using Account.Application.ProcessAccount;
using Account.Application.CacheSession;

namespace Account.API.Src.AccountAreas
{
    // sủ lý tài khoản trên trang home truy cập login 
    // check tài khoản Anonimuos và user
    public class LoginAccountController : Controller
    {
        private readonly ILoginAccount _loginAccount;
        private readonly ICheckRole _checkRole;
        private readonly IProcessAccount _processAccount;
        private readonly ICacheSession _cacheBase;
        public LoginAccountController(ILoginAccount loginAccount, ICheckRole checkRole,
                                      IProcessAccount processAccount, ICacheSession cacheBase)
        {
            _loginAccount = loginAccount; _checkRole = checkRole;
            _processAccount = processAccount; _cacheBase = cacheBase;
        }

        [Route(LoginRouter.LoginAccount)]
        [HttpPost]
        public async Task<IActionResult> LoginAccount([FromBody] AuthenticationInput loginDto)
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ips in host.AddressList)
            {
                if (ips.AddressFamily == AddressFamily.InterNetwork)
                {
                     ips.ToString();
                }
            }
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            var infomation_account = await _loginAccount.LoginUserAccountAsync(loginDto, ip);
            //var role = _checkRole.RoleDtos(infomation_account.UserProfileId);
            var id = Guid.NewGuid().ToString();
            _cacheBase.SetUniqueSession(new SessionCustom
            {
                Id_Session = id,
                Id_User = infomation_account.UserProfileId,
                Account_User = infomation_account.UserName,
                Email = infomation_account.Email,
                Ip = ip,
                Role = null,
                ExpiryDate = DateTime.Now.AddHours(5)
            });
            List<RoleAuthDtos> roles = null; //role.Where(m => m.NameAtomic == "WATCH").Select(m => m.NameResource);
            var tokens = _processAccount.CreateToken(infomation_account, ip); 
            return Ok(new { tokens, roles, infomation_account.Picture,infomation_account.FullName, id });
        }
    }
}
