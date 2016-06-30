using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using RelevantCodes.ExtentReports;

namespace Brother.Tests.Selenium.Lib.ExtentReport
{
    internal static class ExtentManager
    {
        private const string DefaultLogFolder = "C:\\TestAutomation\\AutomationReport";

        private static readonly ExtentReports _Instance =
            new ExtentReports(SetReportLocation(), DisplayOrder.OldestFirst);

        static ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _Instance;
            }
        }


        private static string SetReportLocation()
        {
            var reportLocation = DefaultLogFolder;

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


            const string report = @"\\TestReport.html";
           
            var fullPath = reportLocation + report;

            SpecFlow.SetContext("ReportPath", fullPath);

            return fullPath;
        }

        
    }
}
