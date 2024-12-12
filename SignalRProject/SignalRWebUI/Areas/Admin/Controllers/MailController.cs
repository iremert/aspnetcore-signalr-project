using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Areas.Admin.Dtos.MailDtos;


namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(CreateMailDto createMailDto)
        {
            MimeMessage  mimeMessage =new MimeMessage();



            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalRRezervasyon","iremerturk8@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailbokAddressTo = new MailboxAddress("User",createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailbokAddressTo);

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody=createMailDto.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=createMailDto.Subject;  

            SmtpClient client=new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("iremerturk8@gmail.com", "qkla hiyd gorr isok");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("SendMail");
        }
    }
}
