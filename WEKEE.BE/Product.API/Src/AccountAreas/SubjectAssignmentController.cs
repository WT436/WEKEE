
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.AccountRouter;
using Account.Application.SubjectAssignment;

namespace Product.API.Src.AccountAreas
{
    public class SubjectAssignmentController : Controller
    {
        private readonly ISubjectAssignment _subjectAssignment;
        public SubjectAssignmentController(ISubjectAssignment subjectAssignment)
        {
            _subjectAssignment = subjectAssignment;
        }

        [Route(PermissionRouter.SubjectAssignmentAccount)]
        [HttpGet]
        public async Task<IActionResult> BasicWatch(int id)
        {
            return Ok(await _subjectAssignment.WatchSubjectRole(id_Subject: id));
        }

        [Route(PermissionRouter.SubjectAssignmentAccount)]
        [HttpPost]
        public IActionResult BasicCreate()
        {
            return Ok("true");
        }

        [Route(PermissionRouter.SubjectAssignmentAccount)]
        [HttpPatch]
        public async Task<IActionResult> BasicUpdate(int idSubject, int idRole)
        {
            return Ok(await _subjectAssignment.CreateOrUpdateSubjectAssignment(idSubject: idSubject, idRole: idRole));
        }

        [Route(PermissionRouter.SubjectAssignmentAccount)]
        [HttpDelete]
        public IActionResult BasicDelete()
        {
            return Ok();
        }
    }
}
