using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class ActionAssignmentController : Controller
    {
        private readonly IActionAssignment _actionAssignment;
        public ActionAssignmentController(IActionAssignment actionAssignment)
        {
            _actionAssignment = actionAssignment;
        }

        [Route(PermissionRouter.ActionAssignmentBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.ActionAssignmentBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] ActionAssignmentDto actionAssignmentDto)
        {
            _actionAssignment.UpdateOrInsert(actionAssignmentDto);
            return Ok("true");
        }

        [Route(PermissionRouter.ActionAssignmentBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet(int idPermission, int pageIndex, int pageSize)
        {
            return Ok(_actionAssignment.ListActionAssignment(idPermission: idPermission,
                                                             pagedListInput: new PagedListInput()
                                                             {
                                                                 PageIndex = pageIndex,
                                                                 PageSize = pageSize
                                                             })
            );
        }
    }
}
