using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.AccountRouter;

namespace Product.API.Src.AccountAreas
{
    public class ForgotPasswordController : Controller
    {
        [Route(LoginRouter.ForgotPassword)]
        [HttpGet]
        public IActionResult ForgotPasswordShow()
        {
            return Ok();
        }

        [Route(LoginRouter.ForgotPassword)]
        [HttpPost]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }
    }
}
