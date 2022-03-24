
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.AccountRouter;
using Account.Application.Resource;

namespace Product.API.Src.AccountAreas
{
    public class ConstraintAssignmentController : Controller
    {
        private readonly IResource _resource;
        public ConstraintAssignmentController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.ConstraintAssignmentAccount)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentAccount)]
        [HttpPost]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentAccount)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.ConstraintAssignmentAccount)]
        [HttpPut]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentAccount)]
        [HttpDelete]
        public IActionResult BasicGet()
        {
            return View();
        }
    }
}
