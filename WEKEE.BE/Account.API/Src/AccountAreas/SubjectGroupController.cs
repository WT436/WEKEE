
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Resource;

namespace Account.API.Src.AccountAreas
{
    public class SubjectGroupController : Controller
    {
        private readonly IResource _resource;
        public SubjectGroupController(IResource resource)
        {
            _resource = resource;
        }

        [HttpPatch(PermissionRouter.SubjectGroupAccount)]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [HttpPost(PermissionRouter.SubjectGroupAccount)]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }
    }
}
