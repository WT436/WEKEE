using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class AlgorithmRoleController : Controller
    {
        private readonly IResource _resource;
        public AlgorithmRoleController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.PATCH)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet()
        {
            return View();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }
    }
}
