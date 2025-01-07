using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Core_Proje.Models;

namespace Traversal_Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRquest mailRquest)
        {
            MimeMessage mimeMessage=new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress(mailRquest.Name,mailRquest.SenderMail);
           
            mimeMessage.From.Add(mailboxAddress);
            MailboxAddress mailboxToAddress = new MailboxAddress("User",mailRquest.ReceiverName);

            mimeMessage.To.Add(mailboxToAddress);

            mimeMessage.Subject=mailRquest.Subject;

           // mimeMessage.Body = mailRquest.Body("");

            SmtpClient Client = new SmtpClient();
            Client.Connect("smtp.gmail.com", 587, false);
            Client.Send(mimeMessage);

           // Client.Authenticate(mailRquest.SenderMail);

            Client.Disconnect(true);

            return View();
        }
    }
}
