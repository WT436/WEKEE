using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class SubjectAssignmentController : Controller
    {
        private readonly ISubjectAssignment _subjectAssignment;
        public SubjectAssignmentController(ISubjectAssignment subjectAssignment)
        {
            _subjectAssignment = subjectAssignment;
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.WATCH)]
        [HttpGet]
        public async Task<IActionResult> BasicWatch(int id)
        {
            return Ok(await _subjectAssignment.WatchSubjectRole(id_Subject: id));
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.UPDATE)]
        [HttpGet]
        public async Task<IActionResult> BasicUpdate(int idSubject, int idRole)
        {
            return Ok(await _subjectAssignment.CreateOrUpdateSubjectAssignment(idSubject: idSubject, idRole: idRole));
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.PATCH)]
        [HttpPatch]
        public IActionResult BasicPatch()
        {
            return View();
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet()
        {
            return View();
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }

        [Route(PermissionRouter.SubjectAssignmentBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }
    }
}
