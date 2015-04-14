using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace TestRunner
{
    public class TestHelpers
    {
        public static bool IsTestEnvSet { get; set; }
        public static bool IsBrowserTypeSet { get; set; }
        public static bool IsMailPackageSet { get; set; }
        public static bool IsRunningFromNunitApi { get; set; }
        public static bool IsRunningFromNunitCmd { get; set; }
        public static string RunTimeEnvironment { get; set; }
        public static bool TestRunCancelled { get; set; }
        public static int TestRunProcessId { get; set; }
        public static bool TestRunInProgress { get; set; }

        private static readonly List<string> _checkedItems = new List<string>();
        private static readonly string _specFlowProjectFile;
        private const string TestAssemblyDll = @"Brother.Tests.Specs.dll";
        private const string SpecFlowExe = @"specflow.exe";
        private static readonly string _testAssembly;
        private static readonly string _specFlowPath;


        private static readonly Dictionary<string, string> _browserLookup = new Dictionary<string, string>()
        {
            {"Headless", "HL"},
            {"Chrome", "CH"},
            {"Internet Explorer", "IE"},
            {"FireFox", "FF"}
        };

        static TestHelpers()
        {
            _specFlowProjectFile = ProjectPath.ToLower().Replace(@"bin\debug", @"Brother.Tests.Specs.csproj");
            _testAssembly = String.Format("{0}\\{1}", ProjectPath, TestAssemblyDll);
            _specFlowPath = ProjectPath.ToLower().Replace(@"bin\debug", @"tools\SpecFlow");
        }

        //private static bool ErrorFlag { get; set; }
        //private static string NameSpace { get; set; }
        //private static string TestFeature { get; set; }

        public static string ProjectPath
        {
            get { return Directory.GetCurrentDirectory(); }
        }

        public static string ResultsFileXml
        {
            get
            {
                return string.Format("/xml={0}{1}{2}", ProjectPath.ToLower().Replace(@"bin\debug", "TestResults"), @"\", @"TestResult.xml");
            }
        }

        public static string ResultsFile
        {
            get
            {
                return string.Format("/out={0}{1}{2}", ProjectPath.ToLower().Replace(@"bin\debug", "TestResults"), @"\", @"TestResult.txt");
            }
        }

        public static string SpecFlowHtmlReport
        {
            get
            {
                return string.Format("/out={0}{1}{2}", ProjectPath.ToLower().Replace(@"bin\debug", "TestResults"), @"\", @"SpecFlowRunReport.html");
            }
        }

        public static string TestAssembly
        {
            get { return _testAssembly; }
        }

        public static void ClearSelectedItems()
        {
            _checkedItems.Clear();
        }

        public static void SetSelectedItems(CheckedListBox.CheckedItemCollection checkedItemsList)
        {
            _checkedItems.Clear();
            foreach (var checkedItem in checkedItemsList)
            {
                _checkedItems.Add(checkedItem.ToString());
            }
        }

        public static List<string> GetCdServerList()
        {
            return _checkedItems;
        }

        public static void ShowMessage(string message)
        {
            if (TestRunner.InteractiveExecution)
            {
                MessageBox.Show(message, @"Test Runner Error", MessageBoxButtons.OK);
            }
            else
            {
                Helper.MsgOutput(message);
            }
        }

        public static string ReverseBrowserLookup(string browserType)
        {
            var browser = _browserLookup[browserType];
            return browser;
        }

        public static bool GetTestSettings()
        {
            return (IsTestEnvSet && IsBrowserTypeSet && IsMailPackageSet) &&
                   (IsRunningFromNunitApi || IsRunningFromNunitCmd);
        }

        public static bool GenerateSpecFlowTestRunReport()
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = String.Format(" {0} {1} {2} {3}", "nunitexecutionreport", _specFlowProjectFile, @"/out:", SpecFlowHtmlReport),
                FileName = String.Format("{0}{1}{2}", _specFlowPath, @"\", SpecFlowExe),
                UseShellExecute = true,
                CreateNoWindow = false
            };

            var process = new Process { StartInfo = startInfo };

            try
            {
                if (!process.Start())
                {
                    return false;
                }
                TestRunProcessId = process.Id;
                while (!process.HasExited)
                {

                }
            }
            catch (InvalidOperationException ioError)
            {
                ShowMessage(string.Format("Error generating Specflow Execution report {0}", ioError));
            }
            return false;
        }

        //public static bool GenerateSpecFlowDefinitionReport()
        //{
        //    //   c:\Projects\brother-online\Brother brother\Main\Packages\SpecFlow.1.9.0\Tools\specflow.exe stepdefinitionreport Brother.Tests.Specs.csproj

        //    return false;
        //}
    }
}
