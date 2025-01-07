using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
