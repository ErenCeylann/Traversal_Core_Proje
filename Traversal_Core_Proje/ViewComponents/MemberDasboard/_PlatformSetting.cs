using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.MemberDasboard
{
    public class _PlatformSetting:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
