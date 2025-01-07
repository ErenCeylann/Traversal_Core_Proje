using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Traversal_Core_Proje.Models;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]

    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult addCity(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var value = JsonConvert.SerializeObject(destination);
            return Json(value);
        }

        public IActionResult CityById(int DestinationId)
        {
            var values = _destinationService.GetById(DestinationId);
            if (values == null)
            {

            }
            else
            {
                var jsonValue = JsonConvert.SerializeObject(values);
                return Json(jsonValue);
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateCity(Destination destination)
        {
            var values = _destinationService.GetById(destination.DestinationId);
            if (values==null)
            {

            }
            else
            {
                destination.Reservations = values.Reservations;
                destination.Price = values.Price;
                destination.Status = values.Status;
                destination.Capacity = values.Capacity;
                destination.CoverImage = values.CoverImage;
                destination.Details2 = values.Details2;
                destination.Image = values.Image;
                destination.Image2 = values.Image2;
                _destinationService.TUpdate(destination);
                var v = JsonConvert.SerializeObject(destination);
                return Json(v);
            }
            return View();
        }

        //public static List<City> cities = new List<City>
        //{
        //    new City
        //    {
        //        CityCountry="İtalya",
        //        CityId=1,
        //        CityName="Roma"
        //    },
        //    new City
        //    {
        //        CityId=2,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};


    }
}
