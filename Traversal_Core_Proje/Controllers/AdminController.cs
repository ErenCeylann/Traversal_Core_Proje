using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialAppBrandDemo()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFootor()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}
