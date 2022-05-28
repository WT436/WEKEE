using Account.Application.Service;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class SubjectAdminApiController : Controller
    {
        private readonly ISubjectAdmin _adminSubject;
        public SubjectAdminApiController(ISubjectAdmin adminSubject)
        {
            _adminSubject = adminSubject;
        }

        [HttpGet]
        public async Task<IActionResult> AdminSubject(SearchOrderPageInput input)
        {
            var data = await _adminSubject.GetSubjectPageList(input: input);
            return Ok(data);
        }

        [HttpHead]
        public async Task<IActionResult> AdminSubject(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminSubject([FromBody] SubjectReadDto input)
        {
            int idAccount = 1;
            var data = await _adminSubject.InsertOrUpdateSubject(input: input, idAccount: idAccount);
            return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminSubject([FromBody] SubjectLstChangeDto input)
        {
            var data = await _adminSubject.EditUnitSubject(input: input);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> AdminSubject(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminSubject(List<int> ids)
        {
            var data = await _adminSubject.DeleteSubject(ids);
            return Ok(data);
        }

        [HttpOptions]
        public async Task AdminSubject(int param1, int param2)
        {
        }

        [HttpGet]
        public async Task<IActionResult> AdminRoleFtSubject(SearchOrderPageInput input)
        {
            var data = await _adminSubject.GetSubjectFtRolePageList(input: input);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AdminRoleFtSubject([FromBody] SubjectFtRoleInsertDto input)
        {
            int idAccount = 1;
            var data = await _adminSubject.InsertOrUpdateSubjectFtRole(input: input, idAccount: idAccount);
            return Ok(data);
        }
    }
}
