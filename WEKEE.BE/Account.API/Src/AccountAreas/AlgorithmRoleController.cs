
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Resource;

namespace Account.API.Src.AccountAreas
{
    public class AlgorithmRoleController : Controller
    {
        private readonly IResource _resource;
        public AlgorithmRoleController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.AlgorithmRoleAccount)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleAccount)]
        [HttpPost]
        public IActionResult BasicUpdate()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleAccount)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.AlgorithmRoleAccount)]
        [HttpPut]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.AlgorithmRoleAccount)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }
    }
}
