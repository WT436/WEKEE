using Microsoft.AspNetCore.Mvc;

namespace Product.API.Src.AccountAreas
{
    public class AtomicAdminApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
