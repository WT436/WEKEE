using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Product.API.Src.SystemAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class SystemHomeController : ControllerBase
    {
        public SystemHomeController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
