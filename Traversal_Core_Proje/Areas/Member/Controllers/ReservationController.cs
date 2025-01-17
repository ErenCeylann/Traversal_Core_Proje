﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traversal_Core_Proje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitAccepted(values.Id);
            return View(valueslist);
           
        }

        public async Task <IActionResult> MyApprovalReservation()
        {
            var values= await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitAprroval(values.Id);
            return View(valueslist);
        }

        public async Task <IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitPrevious(values.Id);
            return View(valueslist);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values= (from x in destinationManager.GetList() select new SelectListItem
            {
                Text = x.City,
                Value=x.DestinationId.ToString()
            }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 1;
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
