using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Selenium.Lib.Mail
{
    public static class Mailer
    {
        
        private const string DefaultLogFolder = "C:\\TestAutomation\\AutomationReport\\{0}";
        const string Email = "bieautomation@gmail.com";
        const string Password = "P@$$w0rd123";

        static Attachment _attachment;
        static readonly MailMessage Mail = new MailMessage();


        public static void SendEmail(string address, string subject, string message)
        {
            var dateNow = DateTime.Now.ToString("yyyyMMd");
            var loginInfo = new NetworkCredential(Email, Password);
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            var reportPath = SpecFlow.GetContext("ReportPath");

            _attachment = new Attachment(reportPath);
            

            Mail.From = new MailAddress(Email);
            Mail.To.Add(new MailAddress(address));
            Mail.Subject = subject;
            Mail.Body = message;
            Mail.IsBodyHtml = true;
            

            
            Mail.Attachments.Add(_attachment);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Timeout = 10000;
            smtpClient.Send(Mail);
        }


        public static void SendEmailToMultipleRecipients(string addresses, string subject, string message)
        {
            try
            {
                var loginInfo = new NetworkCredential(Email, Password);
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                var reportPath = SpecFlow.GetContext("ReportPath");
                _attachment = new Attachment(reportPath);

                Mail.From = new MailAddress(Email);
                Mail.Subject = subject;
                Mail.Body = message;
                Mail.IsBodyHtml = true;
                Mail.Attachments.Add(_attachment);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Timeout = 10000;

           
                foreach (var address in addresses.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    Mail.To.Add(new MailAddress(address));
                }
                smtpClient.Send(Mail);
                smtpClient.Dispose();
                Mail.Attachments.Dispose();
            }
            catch (SmtpException smtpException)
            {
                Helper.MsgOutput("Mailing issue - check additional exception information", smtpException.ToString());
            }
           
        }
    }
}
