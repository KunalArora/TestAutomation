using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Core.Filters;
using NUnit.Framework;
using CategoryAttribute = NUnit.Framework.CategoryAttribute;

namespace TestRunner
{

    public partial class BrotherTestRunner : Form
    {
        private static SetCDServers _selectLiveServers;
        private string NameSpace { get; set; }
        private string TestFeature { get; set; }
        private int TestRunProcessId { get; set; }

        public BrotherTestRunner()
        {
            InitializeComponent();
        }

        private void GetAllTests()
        {
            var types = GetTestTypes();
            foreach (var type in types)
            {
                try
                {
                    if ((type.Namespace != null) && (type.Namespace.Contains("TestSpecifications")))
                    {
                        if (!type.Namespace.ToLower().Contains("scratch"))
                        {
                            NameSpace = type.Namespace.Replace("Brother.Tests.Specs.TestSpecifications.", "");
                        }
                    }
                    TestFeature = type.Name.Replace("Feature", " (Feature)");

                    // Add Namespace node checking for duplicates
                    if (TestListView.Nodes[NameSpace] == null)
                    {
                        TestListView.Nodes.Add(NameSpace, NameSpace);
                    }

                    // Add Feature and test nodes
                    AddFeatures(type);
                    AddTestMethods(type);
                }
                catch (Exception ex)
                {
                    Helper.MsgOutput(String.Format(@"Skipping none Feature types [{0}]", ex.Message));
                }
            }
        }

        private void AddTestMethods(Type type)
        {
            // Get Test Methods for all types
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var testAttributes = method.GetCustomAttributes(typeof(TestAttribute), true);
                if (testAttributes.Length <= 0) continue;

                var testCategories = method.GetCustomAttributes(typeof (CategoryAttribute), true);
                
                try
                {
                    if (TestListView.Nodes[NameSpace].Nodes[TestFeature].Nodes[method.Name] == null)
                    {
                        if (testCategories.Length >= 0)
                        {
                            TestListView.Nodes[NameSpace].Nodes[TestFeature].Nodes.Add(method.Name, method.Name);
                        }

                        foreach (CategoryAttribute testCategory in testCategories)
                        {
                            var ignoreAttribute = method.GetCustomAttributes(typeof(IgnoreAttribute), true);
                            var methodName = TestListView.Nodes[NameSpace].Nodes[TestFeature].Nodes[method.Name].Text;
                            var testTag = testCategory.Name;
                            if ((ignoreAttribute != null) && (ignoreAttribute.Length > 0))
                            {
                                testTag = String.Format(" {0} [ {1} ]", testTag, "IGNORE");
                            }
                            methodName = String.Format(" {0} [ {1} ]", methodName, testTag);
                            TestListView.Nodes[NameSpace].Nodes[TestFeature].Nodes[method.Name].Text = methodName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.MsgOutput(@"Skipping invalid Methods ", ex.Message);
                }
            }
        }

        private void AddFeatures(Type type)
        {
            try
            {
                var categories = type.GetCustomAttributes(typeof (CategoryAttribute), true);
                if (categories.Length < 0) return;

                foreach (CategoryAttribute category in categories)
                {
                    if (category.Name.Contains("ignore"))
                    {
                        TestListView.Nodes[NameSpace].Nodes.Add(TestFeature,
                            String.Format("{0} [{1}]", TestFeature, category.Name));
                    }
                    else
                    {
                        if (TestListView.Nodes[NameSpace].Nodes[TestFeature] == null)
                        {
                            TestListView.Nodes[NameSpace].Nodes.Add(TestFeature, String.Format("{0} [{1}]", TestFeature, category.Name));
                        }
                        else
                        {
                            var featureName = TestListView.Nodes[NameSpace].Nodes[TestFeature].Text;
                            featureName = String.Format("{0} [{1}]", featureName, category.Name);
                            TestListView.Nodes[NameSpace].Nodes[TestFeature].Text = featureName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MsgOutput(string.Format(@"Skipping none Feature types {0}", ex.Message));
            }
        }

        private IEnumerable<Type> GetTestTypes()
        {
            Type[] testTypes;

            var assembly = LoadTestAssembly();
            
            try
            {
                testTypes = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }

            return testTypes;
        }

        private Assembly LoadTestAssembly()
        {
            Assembly testAssembly = null;
            try
            {
                testAssembly = Assembly.LoadFile(TestHelpers.TestAssembly);
            }
            catch (FileNotFoundException fileNotFound)
            {
                TestHelpers.ShowMessage(String.Format("Error loading Test Assembly {0} Tried to open file {1}. Make sure this file in the Test Runner root", fileNotFound.Message, TestHelpers.TestAssembly));
            }
            catch (FileLoadException assemblyNotLoaded)
            {
                TestHelpers.ShowMessage(String.Format("Error loading Test Assembly {0}", assemblyNotLoaded.Message));
            }
            return testAssembly;
        }

        private void BrotherTestRunner_Load(object sender, EventArgs e)
        {
            _selectLiveServers = new SetCDServers();
            StopTestRun.Enabled = false;
            RefreshTests.Enabled = false;
            GetAllTests();
            RefreshTests.Enabled = true;
        }

        private void EmailPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emailPackage = EmailPackage.SelectedItem.ToString();
            Email.SetEmailPackage(emailPackage);
            if (Email.CheckEmailPackage(emailPackage))
            {
                TestHelpers.IsMailPackageSet = true;
                return;
            }
            TestHelpers.ShowMessage("@Error setting Email Validation");
            TestHelpers.IsMailPackageSet = false;
        }

        private void RefreshTests_Click(object sender, EventArgs e)
        {
            RefreshTests.Enabled = false;
            GetAllTests();
            RefreshTests.Enabled = true;
        }

        private void RunTimeEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestHelpers.RunTimeEnvironment = RunTimeEnv.SelectedItem.ToString();
            if (TestHelpers.RunTimeEnvironment.Equals("PROD"))
            {
                var result = _selectLiveServers.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LiveCDServerTest.Checked = TestHelpers.GetCdServerList().Count > 0;
                }
            }

            Helper.SetRunTimeEnv(TestHelpers.RunTimeEnvironment);
            if (TestHelpers.RunTimeEnvironment == Helper.GetRunTimeEnv())
            {
                TestHelpers.IsTestEnvSet = true;
                TestsToRun.Text = NUnitHelper.GetNumTests(TestHelpers.RunTimeEnvironment);
                return;
            }
            TestHelpers.ShowMessage(@"Error setting Run Time Environment");
            TestHelpers.IsTestEnvSet = false;
        }

        private void RunTests_Click(object sender, EventArgs e)
        {
            TestHelpers.TestRunCancelled = false;
            StopTestRun.Enabled = true;
                
            if (TestHelpers.GetTestSettings())
            {
                // For now, just set the first CD server (if used) in the list. 
                // ideally this will change over time to run through the entire list
                List<string> cdServerList = TestHelpers.GetCdServerList();
                if (cdServerList.Count > 0)
                {
                    Helper.SetCdServerDmain(cdServerList[0].ToLower().Replace("live site - ", string.Empty));
                }
                TestExecution();
            }
            else
            {
                TestHelpers.TestRunInProgress = false;
                StopTestRun.Enabled = false;
                TestHelpers.ShowMessage("Unable to start Test Run as an Environment option could not be set");
            }
        }

        private void BrowserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var browser = TestHelpers.ReverseBrowserLookup(BrowserType.SelectedItem.ToString());
            WebDriver.SetBrowserType(browser);
            if (browser == WebDriver.GetBrowserType())
            {
                TestHelpers.IsBrowserTypeSet = true;
                return;
            }
            TestHelpers.ShowMessage(@"Error setting Browser Type");
            TestHelpers.IsBrowserTypeSet = false;
        }

       
        public void TestExecution()
        {
            if (NUnitAPIOption.Checked)
            {
//                NUnitFileLoggerAddin.Install();
                TestHelpers.Runner = new Thread(ExecuteWithNunitApi);
                TestHelpers.Runner.IsBackground = true;
                TestHelpers.Runner.SetApartmentState(ApartmentState.STA);
                TestHelpers.Runner.Start();
            }
            else
            {
                ExecuteWithCmdLine();
            }
        }

        public void ExecuteWithNunitApi()
        {
            CoreExtensions.Host.InitializeService();
            var testPath = TestHelpers.TestAssembly;

            var testPackage = new TestPackage(testPath);

            var testRunner = new SimpleTestRunner();
            testRunner.InitializeLifetimeService();
            testRunner.Load(testPackage);

            if (testRunner.Test == null)
            {
                testRunner.Unload();
            }

            TestFilter testFilter = new CategoryFilter("TEST");

            string savedDirectory = Environment.CurrentDirectory;
            TextWriter savedOut = Console.Out;
            TextWriter savedError = Console.Error;

            try
            {
                int tests = testRunner.CountTestCases(testFilter);
                TestResult result = testRunner.Run(new NullListener(), testFilter, true, LoggingThreshold.All);
                Console.WriteLine(result);
            }
            catch
            {
                Environment.CurrentDirectory = savedDirectory;
                Console.SetOut(savedOut);
                Console.SetError(savedError);
            }

        }

        public void ExecuteWithCmdLine()
        {
            LaunchNUnit();
        }

        private void LaunchNUnit()
        {
            var includeFlag = string.Format("{0}{1}", "/include=", TestHelpers.RunTimeEnvironment);
            var startInfo = new ProcessStartInfo
            {
                Arguments = string.Format(" {0} {1} {2} {3}", includeFlag, TestHelpers.ResultsFile, TestHelpers.ResultsFileXml, TestHelpers.TestAssembly),
                FileName = string.Format("{0}{1}{2}", NUnitHelper.NUnitPath, @"\", NUnitHelper.NUnitConsole),
                UseShellExecute = true,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = startInfo };

            try
            {
                if (!process.Start()) return;
                TestRunProcessId = process.Id;
                while (!process.HasExited)
                {
                    TestHelpers.TestRunInProgress = true;

                    if (TestHelpers.TestRunCancelled)
                    {
                        process.Kill();
                        TestHelpers.TestRunInProgress = false;
                    }
                }
                TestHelpers.TestRunInProgress = false;
                StopTestRun.Enabled = false;
                MessageBox.Show(this, @"Test run complete. See Test Report link for results", @"Test Run Completed",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Win32Exception fileNotFound)
            {
                TestHelpers.ShowMessage(string.Format("Unable to find file. \n FileName={0}, Arguments={1}, Reason {2}", startInfo.FileName, startInfo.Arguments, fileNotFound.Message));
            }
        }

        private void NUnitAPIOption_CheckedChanged(object sender, EventArgs e)
        {
            TestHelpers.IsRunningFromNunitApi = true;
            TestHelpers.IsRunningFromNunitCmd = false;
        }

        private void NUnitCmdLineOption_CheckedChanged(object sender, EventArgs e)
        {
            TestHelpers.IsRunningFromNunitApi = false;
            TestHelpers.IsRunningFromNunitCmd = true;
        }

        private void StopTestRun_Click(object sender, EventArgs e)
        {
            TestHelpers.TestRunCancelled = true;
            TestHelpers.ShowMessage("Cancelled by user");
            StopTestRun.Enabled = false;
        }

        private void GenerateRunReport_Click(object sender, EventArgs e)
        {
            if (!TestHelpers.TestRunInProgress)
            {
                TestHelpers.GenerateSpecFlowTestRunReport();
            }
            else
            {
                TestHelpers.ShowMessage("Test Run in Progress - unable to generate report!");
            }
        }
    }
}
