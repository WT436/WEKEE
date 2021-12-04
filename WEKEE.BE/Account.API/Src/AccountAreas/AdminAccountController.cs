using Account.API.SettingUrl.AdminRouter;
using Account.Application.Interface;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Src.AccountAreas
{
    public class AdminAccountController : Controller
    {
        private readonly IAdminAccount _adminAccount;
        public AdminAccountController(IAdminAccount adminAccount)
        {
            _adminAccount = adminAccount;
        }

        [Route(AdminRouter.AdminAccount.LIST)]
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] SearchOrderPageInput orderByPageListInput)
        {
            return Ok(await _adminAccount.GetAllAccount(orderByPageListInput));
        }

        [Route(AdminRouter.AdminAccount.DELETE)]
        [HttpDelete]
        public async Task<IActionResult> Delete( int idAccount)
        {
            return Ok(await _adminAccount.RemoveAccount(id_account: idAccount));
        }

        // chuyển trạng thái tài khoản
        [Route(AdminRouter.AdminAccount.EDIT)]
        [HttpPut]
        public async Task<IActionResult> Edit(int id_account, int is_status)
        {
            return Ok();
        }

        [Route(AdminRouter.AdminAccount.UPDATE)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] List<int> dataDemove)
        {
            return Ok();
        }

    }
}
