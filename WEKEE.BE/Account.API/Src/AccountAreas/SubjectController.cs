using Account.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class SubjectController : Controller
    {
        private readonly ISubject _subject;
        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }

        [Route(PermissionRouter.SubjectBasic.WATCH)]
        [HttpGet]
        public async Task<IActionResult> Watch(int id)
        {
            return Ok(await _subject.LstSubjectAccounts(id_account:id));
        }

        [Route(PermissionRouter.SubjectBasic.CREATE)]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok(await _subject.CreateSubjectAccounts(1));
        }
    }
}
