using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.SpecFlow;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support
{
    [Binding]
    public static class TestController
    {
        public static IWebDriver CurrentDriver { get; set; }
        static int PhantomJsProcId { get; set; }
        static readonly string _driverPort = SeleniumGlobal.Default.DriverPortNumber;
        static readonly string _ipAddress = SeleniumGlobal.Default.DriverIPAddress;

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
                    CurrentDriver = new ChromeDriver();
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

        public static void Test_Teardown()
        {
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
            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                // switch to E: drive on Dev and DV2 
                logLocation = DefaultSeleniumFolder.Replace('C', 'E');
            }
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
