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

        const string Email = "bieautomation@gmail.com";
        const string Password = "P@$$w0rd123";

        static Attachment _attachment;
        static readonly MailMessage Mail = new MailMessage();


        public static void SendEmail(string address, string subject, string message)
        {
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


        public static void SendEmailToMultiple(string addresses, string subject, string message)
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

            try
            {
                foreach (var address in addresses.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    Mail.To.Add(new MailAddress(address));
                }
                smtpClient.Send(Mail);
            }
            catch (SmtpException smtpException)
            {
                Helper.MsgOutput("Mailing issue - check additional exception information", smtpException.ToString());
            }
            finally
            {
                smtpClient.Dispose();
                Mail.Attachments.Dispose();
                Mail.Dispose();
            }
                
        }
    }
}
