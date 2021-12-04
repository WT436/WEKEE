using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class ConstraintAssignmentController : Controller
    {
        private readonly IResource _resource;
        public ConstraintAssignmentController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.PATCH)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet()
        {
            return View();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }

        [Route(PermissionRouter.ConstraintAssignmentBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }
    }
}
