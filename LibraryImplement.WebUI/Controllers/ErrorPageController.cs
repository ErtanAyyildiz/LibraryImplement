using Microsoft.AspNetCore.Mvc;

namespace LibraryImplement.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
