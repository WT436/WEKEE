
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.AccountRouter;
using Account.Application.Subject;

namespace Product.API.Src.AccountAreas
{
    public class SubjectController : Controller
    {
        private readonly ISubject _subject;
        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }

        [Route(PermissionRouter.SubjectAccount)]
        [HttpGet]
        public async Task<IActionResult> Watch(int id)
        {
            return Ok(await _subject.LstSubjectAccounts(id_account:id));
        }

        [Route(PermissionRouter.SubjectAccount)]
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok(await _subject.CreateSubjectAccounts(1));
        }

        [Route(PermissionRouter.SubjectAccount)]
        [HttpPatch]
        public async Task<IActionResult> Update(int i)
        {
            return Ok(await _subject.CreateSubjectAccounts(1));
        }

        [Route(PermissionRouter.SubjectAccount)]
        [HttpPut]
        public async Task<IActionResult> Update(List<int> i)
        {
            return Ok(await _subject.CreateSubjectAccounts(1));
        }

        [Route(PermissionRouter.SubjectAccount)]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok(await _subject.CreateSubjectAccounts(1));
        }
    }
}
