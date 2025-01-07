using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.Controllers
{
    public class Default : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
