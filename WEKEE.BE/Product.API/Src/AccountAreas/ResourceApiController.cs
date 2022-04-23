using Account.Domain.ObjectValues.Input;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    public class ResourceApiController : Controller
    {
        [HttpGet]
        [Route("v1/api/resource")]
        public async Task<IActionResult> ProcessBasicResource(SearchOrderPageInput input)
        {
            return Ok();
        }

        [HttpPost]
        [Route("v1/api/resource")]
        public async Task<IActionResult> ProcessBasicResource()
        {
            return Ok();
        }

        [HttpPatch]
        [Route("v1/api/resource")]
        public async Task<IActionResult> ProcessBasicResource(List<int> ids)
        {
            return Ok();
        }

        [HttpPut]
        [Route("v1/api/resource")]
        public async Task<IActionResult> ProcessBasicResource(int dto)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("v1/api/resource")]
        public async Task<IActionResult> ProcessBasicResource(string a)
        {
            return Ok();
        }
    }
}
