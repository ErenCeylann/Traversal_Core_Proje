using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.Controllers
{
    public class ErorPageController : Controller
    {
        public IActionResult Eror404(int code)
        {
            return View();
        }
    }
}
