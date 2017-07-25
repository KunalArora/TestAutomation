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

            var driveLetter = "C";
            if (isOnBuildMachine.ToLower().Equals("bro43dbs01dop.4") || isOnBuildMachine.ToLower().Equals("bro43dbs01dop.4"))
            {
                driveLetter = "E";
            }
            else if (isOnBuildMachine.ToUpper().Equals("BRO43DBS01DOP.4"))
            {
                driveLetter = "D";
            }

            reportLocation = reportLocation.Replace("C", driveLetter);

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
