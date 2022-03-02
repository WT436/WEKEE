using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Account.API.Src.AccountAreas
{
    public class PermissionAssociateController : Controller
    {
        public async Task<IActionResult> GetPermissionByidAction(int idAction, int pageSize, int pageIndex)
        {
            return Ok();
        }
    }
}
