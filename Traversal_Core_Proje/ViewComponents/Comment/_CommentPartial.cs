using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.Comment
{
    public class _CommentPartial : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var value = commentManager.TGetDestinationById(id);
            ViewBag.count = value.Count;
            return View(value);
        }
    }
}
