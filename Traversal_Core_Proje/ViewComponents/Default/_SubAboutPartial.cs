using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.ViewComponents.Default
{
    public class _SubAboutPartial:ViewComponent
    {

        SubAbouManager abouManager = new SubAbouManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = abouManager.GetList();
            return View(values);
        }
    }
}
