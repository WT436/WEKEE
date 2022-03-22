using Account.Domain.ObjectValues.Input;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Account.API.Src.AccountAreas
{
    public class AtomicAssociateController : Controller
    {
        [HttpGet]
        [Route("/atomic-by-id-action")]
        public async Task<IActionResult> GetAtomicByIdAction(PagedListInput pagedListInput)
        {
            return Ok();
        }
    }
}
