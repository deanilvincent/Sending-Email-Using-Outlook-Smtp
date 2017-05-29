using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SenderApplication.Models;
using System.Net.Mail;

namespace SenderApplication.Controllers
{
    public class EmailSenderController : Controller
    {
        private DbContext db = new DbContext();
        
        [HttpPost]
        public ActionResult EmailSender(string value)
        {
            // From, to, subject, body
            MailMessage mail = new MailMessage("sender@none.com", "receiver@none.com", "Subject Title",
                "<h1>Howdy!</h2><br/><p>You can use different html tags here</p>");
                mail.CC.Add("ccEmailAddress@none.com"); // specify the cc
                mail.IsBodyHtml = true;
                NetworkCredential netCred = new NetworkCredential("senderAccount@none.com", "senderPassword");

                SmtpClient smtpobj = new SmtpClient("smtp-mail.outlook.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;

                smtpobj.Send(mail);

                mail.Dispose();
            }

            return View(value);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
