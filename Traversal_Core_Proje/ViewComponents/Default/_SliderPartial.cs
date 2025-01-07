using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
