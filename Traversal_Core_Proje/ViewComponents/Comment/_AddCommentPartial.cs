using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.Comment
{
    public class _AddCommentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
