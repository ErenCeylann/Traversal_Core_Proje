using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Traversal_Core_Proje.Areas.Admin.Models;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task< IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("http://localhost:53034/api/Visitor");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData=await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> AddVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responMessage = await client.PostAsync("http://localhost:53034/api/Visitor",content);
            if (responMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.DeleteAsync($"http://localhost:53034/api/Visitor/{id}");
            if (responMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync($"http://localhost:53034/api/Visitor/{id}");
            if(responMessage.IsSuccessStatusCode)
            {
                var jsonData=await responMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responMessage = await client.PutAsync($"http://localhost:53034/api/Visitor",content);
            if (responMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }


}
