
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Atomic;

namespace Account.API.Src.AccountAreas
{
    public class AtomicController : Controller
    {
        private readonly IAtomic _atomic;
        public AtomicController(IAtomic atomic)
        {
            _atomic = atomic;
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpPost]
        public IActionResult create()
        {
            return Ok();
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpGet]
        public IActionResult BasicList()
        {
            return Ok(_atomic.GetAll());
        }


        [Route(PermissionRouter.AtomicAccount)]
        [HttpPatch]
        public IActionResult update()
        {
            return Ok();
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}
