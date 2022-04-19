using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Product.API.Src.OrderAreas
{
    public class OrderHomeController : Controller
    {
        [HttpGet]
        [Route("/check-order-account")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
