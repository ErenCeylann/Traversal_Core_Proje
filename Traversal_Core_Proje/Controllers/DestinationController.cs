using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal_Core_Proje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var value=destinationManager.GetById(id);
           ViewBag.i=id;
            return View(value);  
        }
        [HttpPost]
        public IActionResult DestinationDetail(Destination p)
        {
            return View();
        }
    }
}
