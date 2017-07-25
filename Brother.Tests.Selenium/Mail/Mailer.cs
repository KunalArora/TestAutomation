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
        
        private const string DefaultLogFolder = @"C:\\TestAutomation\\AutomationReport";
        private const string NewReportFolder = @"C:\\TestAutomation\\AutomationReport\\{0}";
        private const string ReportName = @"TestReport.html";
        private const string NewReportName = @"TestReport_{0}.html";

        const string ReportPath = DefaultLogFolder + "\\" + ReportName;
        //const string Email = "bieautomation@gmail.com";
        //const string Password = "P@$$w0rd123";

        const string Email = "sayo.afolabi@brother.co.uk";
        

        static Attachment _attachment;
        static readonly MailMessage Mail = new MailMessage();


        public static void SendEmailWithAttachment(string address, string subject, string message, string path)
        {
           
            try
            {
                //var loginInfo = new NetworkCredential(Email, Password);
                //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                var smtpClient = new SmtpClient("eusmtp.eu.brothergroup.net", 25);
                //var reportPath = SpecFlow.GetContext("ReportPath");
                _attachment = new Attachment(path);

                Mail.From = new MailAddress(Email);
                Mail.Subject = subject;
                Mail.Body = message;
                Mail.IsBodyHtml = true;
                Mail.Attachments.Add(_attachment);

                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
                smtpClient.Timeout = 10000;
                Mail.To.Add(new MailAddress(address));
                smtpClient.Send(Mail);
                smtpClient.Dispose();
                Mail.Attachments.Dispose();
            }
            catch (SmtpException smtpException)
            {
                Helper.MsgOutput("Mailing issue - check additional exception information", smtpException.ToString());
            }
        }

        public static void SendEmailWithoutAttachment(string address, string subject, string message)
        {

            try
            {
                //var loginInfo = new NetworkCredential(Email, Password);
                //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                var smtpClient = new SmtpClient("eusmtp.eu.brothergroup.net", 25);
                //var reportPath = SpecFlow.GetContext("ReportPath");
                //_attachment = new Attachment(path);

                Mail.From = new MailAddress(Email);
                Mail.Subject = subject;
                Mail.Body = message;
                Mail.IsBodyHtml = true;
               // Mail.Attachments.Add(_attachment);

                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
                smtpClient.Timeout = 10000;
                Mail.To.Add(new MailAddress(address));
                smtpClient.Send(Mail);
                smtpClient.Dispose();
                Mail.Attachments.Dispose();
            }
            catch (SmtpException smtpException)
            {
                Helper.MsgOutput("Mailing issue - check additional exception information", smtpException.ToString());
            }
        }


        public static void SendEmailToMultipleRecipients(string addresses, string subject, string message)
        {
            
            CopyReportToNewLocation();

            try
            {
                //var loginInfo = new NetworkCredential(Email, Password);
                //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                var smtpClient = new SmtpClient("eusmtp.eu.brothergroup.net", 25);
                //var reportPath = SpecFlow.GetContext("ReportPath");
                _attachment = new Attachment(ReportPath);

                Mail.From = new MailAddress(Email);
                Mail.Subject = subject;
                Mail.Body = message;
                Mail.IsBodyHtml = true;
                Mail.Attachments.Add(_attachment);

                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = loginInfo;
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
           
            DeleteReportFile();
        }

        private static void CopyReportToNewLocation()
        {
            var isOnBuildMachine = Environment.MachineName;
            var dateNow = DateTime.Now.ToString("yyyyMMd");

            var timeNow = DateTime.Now.ToString("HHmmss");

            var newReportLoc = String.Format(NewReportFolder, dateNow);

            var newReportName = String.Format(NewReportName, timeNow);

            var driveLetter = "C";
            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                driveLetter = "E";
            }
            else if (isOnBuildMachine.ToUpper().Equals("bro43dbs01dop"))
            {
                driveLetter = "D";
            }

            newReportLoc = newReportLoc.Replace("C", driveLetter);
            newReportName = newReportName.Replace("C", driveLetter);

            Helper.CopyFileToNewLocation(DefaultLogFolder, newReportLoc, ReportName, newReportName);
        }

        private static void DeleteReportFile()
        {
            Helper.DeleteFileFromDirectory(ReportPath);
        }
    }
}
