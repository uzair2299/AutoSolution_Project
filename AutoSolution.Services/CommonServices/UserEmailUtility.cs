using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.CommonServices
{
    public class UserEmailUtility
    {
        public static void SendEmailToUser(string EmailId, string UrlLink)
        { 

            var fromMail = new MailAddress("uzairanwar2299@gmail.com", "Uzair"); // set your email  
            var fromEmailpassword = "@@@@@@0000003333337949900"; // Set your password   
            var toEmail = new MailAddress(EmailId, "Receiver");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword)
            };

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Auto Solution Account Verifivation";
            Message.Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
                           "<br/><br/><a href=" + UrlLink + ">" + UrlLink + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
    }
}
