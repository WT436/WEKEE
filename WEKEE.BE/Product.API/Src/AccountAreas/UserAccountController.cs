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

        public UserAccountController(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        [HttpGet]
        public async Task<IActionResult> LoginAccount()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount([FromBody] UserProfileInsertDto input)
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string IpV4 = string.Empty;
            string IpV6 = string.Empty;
            foreach (var ip in host.AddressList)
            {
                // var is_v4 = RegexProcess.Regex_IsMatch(RegexProcess.CHECK_IP_V4, ip.ToString());
                // var is_v6 = RegexProcess.Regex_IsMatch(RegexProcess.CHECK_IP_V6, ip.ToString());
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IpV4 = IpV4 + ip.ToString() + "|";
                }

                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    IpV6 = IpV6 + ip.ToString() + "|";
                }
            };

            await _userAccount.RegistrationAccount(input, IpV4: IpV4, IpV6: IpV6);
            return Ok(true);
        }
    }
}
