using Account.Application.Interface;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class AuthenV2GoogleController : Controller
    {
        private readonly IUserAccount _userAccount;
        private readonly IProcessIPClient _processIPClient;
        public AuthenV2GoogleController(IUserAccount userAccount, IProcessIPClient processIPClient)
        {
            _processIPClient = processIPClient;
            _userAccount = userAccount;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenV2ReadDto input)
        {
            var ip = await _processIPClient.GetIpClient();
            var data = await _userAccount.LoginOAuthV2(input, ip.IpV4, ip.IpV6);
            return Ok(data);
        }
    }
}
