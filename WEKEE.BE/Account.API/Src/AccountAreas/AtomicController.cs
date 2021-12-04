using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class AtomicController : Controller
    {
        private readonly IAtomic _atomic;
        public AtomicController(IAtomic atomic)
        {
            _atomic = atomic;
        }

        [Route(PermissionRouter.AtomicBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList()
        {
            return Ok(_atomic.GetAll());
        }

    }
}
