using Microsoft.AspNetCore.Mvc;
using Utils.Exceptions;

namespace Assessment.API.Src.Controllers
{
    public class InvalidController : Controller
    {
        public IActionResult IndexErrorServer500()
        {
            throw new ServerException(500,"");
        }

        public IActionResult IndexErrorClient404()
        {
            throw new ClientException(404, "Bố bổ cái bàn phím vào đầu mày giờ. Đi chỗ khác chơi đi mày.");
        }

        public IActionResult IndexErrorClient401()
        {
            throw new ClientException(401, "Not Found!");
        }

        public IActionResult IndexErrorClient405()
        {
            throw new ClientException(405, "");
        }
    }
}
