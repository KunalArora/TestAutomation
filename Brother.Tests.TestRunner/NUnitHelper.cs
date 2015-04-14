using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Core.Filters;

namespace TestRunner
{
    public class NUnitHelper
    {
        // Nunit Declarations
        private const string _nUnitConsole = "nunit-console-x86.exe";

        private static readonly string _resultsFile = String.Format("/out={0}{1}{2}",
            TestHelpers.ProjectPath.ToLower().Replace(@"bin\debug", "TestResults"), @"\", @"TestResult.txt");

        private static readonly string _resultsFileXml = String.Format("/xml={0}{1}{2}",
            TestHelpers.ProjectPath.ToLower().Replace(@"bin\debug", "TestResults"), @"\", @"TestResult.xml");

        //private static string includeFlag = string.Format("{0}{1}", "/include=", RunTimeEnv.SelectedItem.ToString());
        private static readonly string _nUnitPath = TestHelpers.ProjectPath.ToLower().Replace(@"bin\debug", @"tools\NUnit");

        public static string NUnitConsole
        {
            get { return _nUnitConsole; }
        }

        public static string NUnitPath
        {
            get { return _nUnitPath; }
        }
        public static string GetNumTests(string category)
        {
            CoreExtensions.Host.InitializeService();

            var testPath = TestHelpers.TestAssembly;

            var testPackage = new TestPackage(testPath);

            var testRunner = new SimpleTestRunner();
            testRunner.InitializeLifetimeService();
            testRunner.Load(testPackage);

            TestFilter testFilter = new CategoryFilter(category);
            return testRunner.CountTestCases(testFilter).ToString();
        }
    }
}
