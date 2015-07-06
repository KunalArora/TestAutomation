using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Core.Filters;

namespace TestRunner
{
    [NUnitAddin(Name = "File Logger", Description = "Writes test result to file",Type = ExtensionType.Core)]
    public partial class NUnitFileLoggerAddin : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            var listeners = host.GetExtensionPoint("EventListeners");
            if (listeners == null)
                return false;

            listeners.Install(this);
            return true;
        }

        public void TestFinished(TestResult result)
        {
            using (var file = File.Open("Log.txt", FileMode.Append))
            using (var writer = new StreamWriter(file))
            {
                var message = string.Format("[{0:s}] [{1}] {2}", DateTime.Now,
                    result.ResultState, result.Name);
                writer.WriteLine(message);
                var isFailure =
                    result.ResultState == ResultState.Error ||
                    result.ResultState == ResultState.Failure;
                if (isFailure)
                {
                    writer.WriteLine(result.Message);
                }
            }
        }
    }

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
