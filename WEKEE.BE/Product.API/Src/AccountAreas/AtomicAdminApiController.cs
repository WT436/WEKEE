using Account.Application.Interface;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.AtomicDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class AtomicAdminApiController : Controller
    {
        private readonly IAtomicAdmin _adminAtomic;
        public AtomicAdminApiController(IAtomicAdmin adminAtomic)
        {
            _adminAtomic = adminAtomic;
        }

        [HttpGet]
        public async Task<IActionResult> AdminAtomic(SearchOrderPageInput input)
        {
            var data = await _adminAtomic.GetAtomicPageList(input: input);
            return Ok(data);
        }

        [HttpHead]
        public async Task<IActionResult> AdminAtomic(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminAtomic([FromBody] AtomicReadDto input)
        {
            int idAccount = 1;
            var data = await _adminAtomic.InsertOrUpdateAtomic(input: input, idAccount: idAccount);
            return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminAtomic([FromBody] AtomicLstChangeDto input)
        {
            var data = await _adminAtomic.EditUnitAtomic(input: input);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> AdminAtomic(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminAtomic(List<int> ids)
        {
            var data = await _adminAtomic.DeleteAtomic(ids);
            return Ok(data);
        }

        [HttpOptions]
        public async Task AdminAtomic(int param1, int param2)
        {
        }
    }
}
