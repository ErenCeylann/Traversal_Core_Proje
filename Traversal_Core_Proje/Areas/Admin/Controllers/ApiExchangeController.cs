using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Traversal_Core_Proje.Areas.Admin.Models;
using Newtonsoft.Json;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiExchangeController : Controller
    {
        public async Task< IActionResult> Index()
        {
            List<BookingExchangeViewModel> bookingExchangeViewModels = new List<BookingExchangeViewModel>();
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=USD"),
                Headers =
    {
        { "x-rapidapi-key", "2518e4f78dmshe918a4a9bffab84p16f6c6jsn4c12d43322b0" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<BookingExchangeViewModel>(body);
                return View(values.exchange_rates);
            }
          
        }
    }
}
