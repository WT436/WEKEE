
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Atomic;
using System.Threading.Tasks;
using Account.Domain.ObjectValues.Enum;

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
        public IActionResult Create()
        {
            return Ok();
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpGet]
        public async Task<IActionResult> GetData(SearchOrderPageInput searchOrderPageInput)
        {
            return Ok(await _atomic.ListAtomicBasicAsync(searchOrderPageInput));
        }


        [Route(PermissionRouter.AtomicAccount)]
        [HttpPatch]
        public IActionResult Update()
        {
            return Ok();
        }

        [Route(PermissionRouter.AtomicAccount)]
        [HttpPut]
        public IActionResult Update(int a)
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
