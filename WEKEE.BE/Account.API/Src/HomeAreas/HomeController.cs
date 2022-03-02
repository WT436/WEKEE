using Microsoft.AspNetCore.Mvc;

namespace Account.API.Src.HomeAreas
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
