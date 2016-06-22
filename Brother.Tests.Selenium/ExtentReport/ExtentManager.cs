using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

namespace Brother.Tests.Selenium.Lib.ExtentReport
{
    internal class ExtentManager
    {
        private const string DefaultLogFolder = "C:\\TestAutomation\\AutomationReport\\{0}\\{1}.html";

        private static readonly ExtentReports _Instance =
            new ExtentReports(SetReportLocation(), DisplayOrder.OldestFirst);

        static ExtentManager() { }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _Instance;
            }
        }


        private static string SetReportLocation()
        {
            var dateNow = DateTime.Now.Date.ToString().Replace(@"/", "").Replace(@" ", "").Replace(@":", "");
            var dateN = dateNow.Substring(0, 8);

            var timeNow = DateTime.Now.TimeOfDay.ToString().Replace(@"/", "").Replace(@" ","").Replace(@":","").Replace(@".","");
            var timeN = timeNow.Substring(0, 6);

            var reportLocation = String.Format(DefaultLogFolder, dateN, timeN);

            var isOnBuildMachine = Environment.MachineName;

            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                // switch to E: drive on Dev and DV2 
                reportLocation = reportLocation.Replace('C', 'E');
            }
            if (!Directory.Exists(reportLocation))
            {
                Directory.CreateDirectory(reportLocation);
            }

            return reportLocation;
        }
    }
}
