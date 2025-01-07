using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;

        public UserController(IUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _userService.GetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _userService.GetById(id);
            _userService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _userService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _userService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser()
        {
            _userService.GetList();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByWaitAccepted(id);
            return View(values);
        }
    }
}
