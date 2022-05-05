using Account.Application.Interface;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Utils.Any;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class UserAccountController : Controller
    {
        private readonly IUserAccount _userAccount;
        private readonly IProcessIPClient _processIPClient;

        public UserAccountController(IUserAccount userAccount, IProcessIPClient processIPClient)
        {
            _userAccount = userAccount;
            _processIPClient = processIPClient;
        }

        [HttpPost]
        public async Task<IActionResult> StopImpersonationAccount()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> ImpersonationAccount()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAccount()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> LogoutAccount()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAccount([FromBody] AuthenticationInput input)
        {
            var ip = await _processIPClient.GetIpClient();
            var data = await _userAccount.LoginAccount(input, ip.IpV4, ip.IpV6);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationAccount([FromBody] UserProfileInsertDto input)
        {
            var ip = await _processIPClient.GetIpClient();
            await _userAccount.RegistrationAccount(input, IpV4: ip.IpV4String, IpV6: ip.IpV6String);
            return Ok(true);
        }
    }
}
