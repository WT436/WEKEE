
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.ActionAssignment;
using Account.Domain.ObjectValues.Enum;

namespace Account.API.Src.AccountAreas
{
    public class ActionAssignmentController : Controller
    {
        private readonly IActionAssignment _actionAssignment;
        public ActionAssignmentController(IActionAssignment actionAssignment)
        {
            _actionAssignment = actionAssignment;
        }

        [Route(PermissionRouter.ActionAssignmentAccount)]
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

        [Route(PermissionRouter.ActionAssignmentAccount)]
        [HttpPatch]
        public IActionResult BasicUpdate([FromBody] ActionAssignmentDto actionAssignmentDto)
        {
            _actionAssignment.UpdateOrInsert(actionAssignmentDto);
            return Ok("true");
        }
    }
}
