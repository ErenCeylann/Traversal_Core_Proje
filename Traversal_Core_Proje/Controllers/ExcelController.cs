using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Ink;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Traversal_Core_Proje.Models;

namespace Traversal_Core_Proje.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();

            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Capasity = x.Capacity,
                    Price = x.Price
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "file1.xlsx");
            //ExcelPackage excelPackage = new ExcelPackage();
            //var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            //workSheet.Cells[1, 1].Value = "Rota";
            //workSheet.Cells[1, 2].Value = "Rehber";
            //workSheet.Cells[1, 3].Value = "Kontenjan";

            //workSheet.Cells[2, 1].Value = "Gürcistan Batum";
            //workSheet.Cells[2, 2].Value = "Kadir Yıldız";
            //workSheet.Cells[2, 3].Value = "50";

            //var bytes = excelPackage.GetAsByteArray();
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "file1.xlsx");
        }

        public IActionResult ExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowcount = 2;
                foreach (var item in DestinationList())
                {
                    
                    workSheet.Cell(rowcount,1).Value = item.City;
                    workSheet.Cell(rowcount,2).Value = item.DayNight;
                    workSheet.Cell(rowcount,3).Value = item.Price;
                    workSheet.Cell(rowcount,4).Value = item.Capasity;
                    rowcount++;
                }
                using (var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
