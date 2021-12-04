using Account.Application.Interface;
using Account.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utils.Exceptions;
using Account.API.SettingUrl.AdminRouter;

namespace Account.API.Src.AccountAreas
{
    public class AdminProcessController : Controller
    {
        private readonly IAccountAdminProcess _accountAdminProcess;
        public AdminProcessController(IAccountAdminProcess accountAdminProcess)
        {
            _accountAdminProcess = accountAdminProcess;
        }

        [Route(AdminRouter.AdminProcessAccount.PATCH)]
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] AccountAdminCreate accountAdminCreate)
        {
            if(accountAdminCreate==null)
            {
                throw new ClientException(400, "Data null!");
            }
            string ipUser = "1.54.195.166";
            string userAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36";
            await _accountAdminProcess.InsertOrUpdateAccount(accountAdminCreate: accountAdminCreate,
                                                             ipUser: ipUser,
                                                             userAgent: userAgent);
            return Ok("true");
        }

    }
}
