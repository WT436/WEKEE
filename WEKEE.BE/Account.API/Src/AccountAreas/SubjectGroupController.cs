using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class SubjectGroupController : Controller
    {
        private readonly IResource _resource;
        public SubjectGroupController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.SubjectGroupBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectGroupBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectGroupBasic.PATCH)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.SubjectGroupBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectGroupBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet()
        {
            return View();
        }

        [Route(PermissionRouter.SubjectGroupBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectGroupBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectGroupBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }
    }
}
