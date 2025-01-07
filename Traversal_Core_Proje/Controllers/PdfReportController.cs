using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Traversal_Core_Proje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Treversal rezervasyon pdf raporu");

            document.Add(paragraph);

            document.Close();

            return File("/PdfReport/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            
            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir Tc");


            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("Yücedağ");
            pdfPTable.AddCell("11122233344");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Su");
            pdfPTable.AddCell("11122233344");
            
            document.Add(pdfPTable);
            

            document.Close();

            return File("/PdfReport/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
