using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values=_contactUsService.TGetListContactUsByTrue();
            return View(values);
        }
        
        public IActionResult ContactUsChangToFalse(int id)
        {
            _contactUsService.TContactUsStatusChangToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
