using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using Brother.Tests.Selenium.Lib.ExtentReport;
using Brother.Tests.Selenium.Lib.Mail;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.SpecFlow;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support
{
    [Binding]
    public static class TestController
    {
        public static IWebDriver CurrentDriver { get; set; }
        private static ExtentReports _extent;
        private static ExtentTest _test;
        static int PhantomJsProcId { get; set; }
        static readonly string _driverPort = SeleniumGlobal.Default.DriverPortNumber;
        static readonly string _ipAddress = SeleniumGlobal.Default.DriverIPAddress;
        private const string Message = "Please find attached the latest Automation Test Report which was generated on {0}. You can open the attachment using any browser.";
        private const string Subject = "Automation Test Report";
        private const string To = "steve.walters@brother.co.uk";


        static TestController()
        {
            IsAcceptCookiesDismissed = false;
        }

        public static bool IsHeadlessRunning { get; set; }
        public static bool IsAcceptCookiesDismissed { get; set; }

        private const string DefaultLogFolder = "C:\\TestAutomation\\SeleniumLogging";
        private const string DefaultSeleniumFolder = "C:\\TestAutomation\\SnapShots";
        
        /// <summary>
        /// Overridden Test_Setup - Release mode only
        /// </summary>
        public static void HeadlessRunning()
        {
            IsHeadlessRunning = true;
            
            IsAcceptCookiesDismissed = false;
            CurrentDriver = UsePhantomJsAsService();

            if (CurrentDriver == null)
            {
                TestCheck.AssertFailTest("FATAL: Unable to create a new Remote WebDriver instance");
                ExtentLogFatalInformation();
            }
            SetWebDriverTimeouts(CurrentDriver);
            
            Helper.MsgOutput("Using HEADLESS Capabilities");
        }

        public static void SetWebDriverTimeouts(IWebDriver driver)
        {
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.PageLoad);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Script);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            driver.Manage().Window.Maximize();
            
            
        }

        private static IWebDriver UsePhantomJsAsService()
        {
            IWebDriver newDriver = null;
            var phantomJsService = StartPhantomJsService();
            newDriver = new PhantomJSDriver(phantomJsService);
            return newDriver;
        }

        public static IWebDriver ConnectToBrowserStack()
        {
            var browserStacjUri = ConfigurationManager.AppSettings["BrowserStackHubUri"];
            var capabilities = SetBrowserStackDesiredCapabilities();
            IWebDriver newDriver = null;

            try
            {
                Helper.MsgOutput(string.Format("INFORMATION: About to create connect to Browser Stack"));
                Helper.MsgOutput("Creating new Remote Web Driver instance to Browser Stack with 1 minute timeout");
                newDriver = new RemoteWebDriver(new Uri(browserStacjUri), capabilities, new TimeSpan(0, 0, 1, 0));
            }
            catch (WebDriverException webDriverException)
            {
                Test_Teardown();
                Helper.MsgOutput(string.Format("{0} - {1}", "Unable to Connect to GhostDriver via RemoteWebDriver", webDriverException.Message));
            }
            catch (System.Net.WebException webException)
            {
                Test_Teardown();
                Helper.MsgOutput(string.Format("{0} - {1}", "Unable to Connect to GhostDriver via RemoteWebDriver", webException.Message));
            }
            return newDriver;
        }

        public static void Test_Setup()
        {
            var browserType = WebDriver.GetBrowserType();
            IsHeadlessRunning = false;
            IsAcceptCookiesDismissed = false;
            switch (browserType)
            {
                case "IE":
                    CurrentDriver = new InternetExplorerDriver(IeOptions());
                    Helper.MsgOutput("Using IE Driver");
                    break;

                case "CH":
                    CurrentDriver = new ChromeDriver(Options());
                    Helper.MsgOutput("Using Chrome Driver");
                    break;

                case "FF":
                    CurrentDriver = new FirefoxDriver();
                    Helper.MsgOutput("Using FireFox Driver");
                    break;

                case "BRS":
                    CurrentDriver = ConnectToBrowserStack();
                    Helper.MsgOutput("Using BrowserStack");
                    break;

                case "HL":
                    if (Utils.IsPortAvailable(_ipAddress, Convert.ToInt32(_driverPort)))
                    {
                        HeadlessRunning();
                    }
                    break;

                default:
                    throw new SpecFlowSeleniumException("Unable to detect Browser type");
            }

            SetWebDriverTimeouts(CurrentDriver);
            Helper.MsgOutput("!!!We are up and running!!!");
        }

        public static void InitialiseReport()
        {
            _extent = ExtentManager.Instance;
            _test = _extent.StartTest(TestContext.CurrentContext.Test.Name);
            _test.Log(LogStatus.Info, String.Format("{0} is up and running", TestContext.CurrentContext.Test.Name));
        }


        public static void ExtentTearDown()
        {
            try
            {
                ExtentReportCaptureTearDown();

            }
            catch (IOException ioException)
            {
                Helper.MsgOutput("Report could not be written to specified location", ioException.ToString());
            }
        }

        public static void SendEmail()
        {
            var dateNow = DateTime.Now.ToString("F");

            if (Helper.IsMpsSwitchOn())
            {
                //Mailer.SendEmailWithAttachment(To, Subject, String.Format(Message, dateNow));
                Mailer.SendEmailToMultipleRecipients(To, Subject, String.Format(Message, dateNow));
            }
        }

        public static void Test_Teardown()
        {
           ExtentTearDown();
            try
            {
                if (IsDriverRunning(CurrentDriver))
                {
                    try
                    {
                        WebDriver.DeleteAllCookies();
                        CurrentDriver.Close();
                        CurrentDriver.Quit();
                    }
                    catch (SpecFlowSeleniumException ex)
                    {
                        Helper.MsgOutput("Unable to Quit current driver", ex.ToString());
                    }
                }
                KillPhantomJsIfRunning();
                CurrentDriver = null;
                Helper.MsgOutput(String.Format("Selenium stopped @ {0}", DateTime.Now.ToString("dd-MM-yyyy H:mm:ss")));
            }
            catch (NullReferenceException nullReferenceException)
            {
                Helper.MsgOutput(nullReferenceException.ToString());
            }
        }


        public static void ExtentLogScreenshotLocation(string path)
        {
            _test.Log(LogStatus.Info, "The screenshot of the failed page is attached below: " + _test.AddScreenCapture(path));
        }

        public static void ExtentLogPassInformation(string step)
        {
            var text = String.Format("{0} step has been successfully completed", step);
            _test.Log(LogStatus.Pass, text);
        }
        public static void ExtentLogFailInformation(string step, string message, string[] categories = null)
        {
            var text = String.Format("{0} failed because of the following error message {1}", step, message);

            if (categories != null)
            {
                _test.AssignCategory(categories);
            }

            _test.Log(LogStatus.Fail, text);
        }

        public static void ExtentLogFatalInformation()
        {
            const string text = "Unable to create a new Remote WebDriver instance";
            _test.Log(LogStatus.Fatal, text);
        }

        public static void ExtentLogInformation(string value, string enteredOrRetrieved)
        {
            var text = String.Format("{0} has been successfully {1}", value, enteredOrRetrieved);
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentLogFeatureInformation(string value)
        {
            var text = String.Format("{0} has finished running", value);
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentLogInformation()
        {
            const string text = "Step successfully completed";
            _test.Log(LogStatus.Info, text);
        }

        public static void ExtentIgnoreInformation(string message)
        {
            _test.Log(LogStatus.Info, message);
        }

        public static void ExtentReportCaptureTearDown()
        {
            //var status = TestContext.CurrentContext.Result.Status;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus);

            _extent.EndTest(_test);
            _extent.Flush();
        }

        private static InternetExplorerOptions IeOptions()
        {
            var port = @" --" + _driverPort;
            return new InternetExplorerOptions
            {
                EnablePersistentHover = false,
                RequireWindowFocus = true,
                EnableNativeEvents = false,
                BrowserCommandLineArguments = port,
                IgnoreZoomLevel = true
            };
        }

        private static ChromeOptions Options()
        {
            //var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            var options = new ChromeOptions();
            const string path = @"C:\DataTest";

            //if (!string.IsNullOrWhiteSpace(scenarioName))
            //{
            //    scenarioName = scenarioName.Replace(" ", "");

            //    if (scenarioName.Length > 50)
            //    {
            //        scenarioName = scenarioName.Substring(0, 50);
            //    }
            //    path = Path.Combine(path, scenarioName);
            //    //path += scenarioName; //String.Format(@"C:\DataTest\{0}", scenarioName);
            //}
            
            
            options.AddArguments("--disable-extensions");
           // options.AddArguments("start-maximized");
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("download.default_directory", path);
            options.AddArguments("no-sandbox");

            return options;
        }

        private static bool IsDriverRunning(IWebDriver driver)
        {
            return driver != null;
        }

        public static void KillPhantomJs(int processId)
        {
            var phantomJsProcess = Process.GetProcessById(processId);
            try
            {
                if (!phantomJsProcess.HasExited)
                {
                    phantomJsProcess.Kill();
                }
            }
            catch (InvalidOperationException invalidOperation)
            {
                Helper.MsgOutput("Unable to kill Rogue PhantomJS processes as they are likely to be dead already", invalidOperation.Message);
            }
        }


        public static void KillPhantomJsIfRunning()
        {
            while (!IsProcessRunning("phantomJS"))
            {
                WebDriver.Wait(Helper.DurationType.Millisecond, 500);
                Helper.MsgOutput("Closing PhantomJS processes");
            }

            while (!IsProcessRunning("chromedriver"))
            {
                WebDriver.Wait(Helper.DurationType.Millisecond, 500);
                Helper.MsgOutput("Closing PhantomJS processes");
            }
        }

        private static bool IsProcessRunning(string processName)
        {
            var phantomJsProcessList = Process.GetProcessesByName(processName);
            foreach (var proc in phantomJsProcessList)
            {
                try
                {
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                        proc.WaitForExit(50);
                    }
                }
                catch (InvalidOperationException invalidOperation)
                {
                    Helper.MsgOutput("Unable to kill Rogue PhantomJS processes as they are likely to be dead already", invalidOperation.Message);
                }
            }
            phantomJsProcessList = Process.GetProcessesByName(processName);
            return phantomJsProcessList.Length == 0;
        }

      
        private static PhantomJSDriverService StartPhantomJsService()
        {
            KillPhantomJsIfRunning();
            
            var phantomJsService = PhantomJSDriverService.CreateDefaultService(string.Format(@"{0}\Drivers\", Directory.GetCurrentDirectory()));
            phantomJsService.IgnoreSslErrors = true;
            phantomJsService.WebSecurity = false;
            phantomJsService.AddArgument("--web-security=no");
            phantomJsService.AddArgument("--ignore-ssl-errors=true");
            phantomJsService.AddArgument("--ssl-protocol=any");
            phantomJsService.AddArgument("--local-to-remote-url-access=true");
            phantomJsService.LogFile = SetDriverLog();

            return phantomJsService;
        }

        private static string SetDriverLog()
        {
            var logLocation = DefaultLogFolder;
            var isOnBuildMachine = Environment.MachineName;
            var driveLetter = "C";
            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                driveLetter = "E";
            }
            else if (isOnBuildMachine.ToLower().Equals("bro43dbs01dop"))
            {
                driveLetter = "D";
            }
            logLocation = DefaultSeleniumFolder.Replace("C", driveLetter);
            if (!Directory.Exists(logLocation))
            {
                Directory.CreateDirectory(logLocation);
            }

            return logLocation + "\\PhantomLog.log";
        }

        private static DesiredCapabilities SetBrowserStackDesiredCapabilities()
        {
            // set to Chrome by default - need to add options for other drivers
            var capabilities = DesiredCapabilities.Chrome();

            capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["BrowserStackUser"]);
            capabilities.SetCapability("browserstack.key", ConfigurationManager.AppSettings["BrowserStackKey"]);

            capabilities.SetCapability("browser", "Chrome");
            capabilities.SetCapability("browser_version", "44.0");
            capabilities.SetCapability("os", "Windows");
            capabilities.SetCapability("os_version", "7");
            capabilities.SetCapability("resolution", "1024x768");
            capabilities.SetCapability("acceptSslCerts", true);
            capabilities.SetCapability("javascriptEnabled", true);
            capabilities.SetCapability("web-security", false);
            capabilities.SetCapability("ignore-sss-errors", true);
            capabilities.SetCapability("unexpectedAlertBehaviour", "accept");
            capabilities.SetCapability("browserstack.local", "true");
            capabilities.SetCapability("disable-popup-blocking", false);

            if (capabilities.IsJavaScriptEnabled)
            {
                Helper.MsgOutput("Driver Capabilities", "Javascript support is Enabled");
            }

            return capabilities;
        }
    }
}
