using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.SpecFlow;
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
            // NOTE: Unable to use without larger changes to project, including IWebDriver references replaced with PhantomJSDriver
            var usePhantomJsService = SeleniumGlobal.Default.UsePhantomJsService;
            if (Convert.ToBoolean(usePhantomJsService))
            {
                var phantomDriverService = StartPhantomJsService();
                phantomDriverService.Start();
                var jsOptions = SetJsOptions();
                CurrentDriver = new PhantomJSDriver(phantomDriverService, jsOptions);
            }
            else
            {
                IsAcceptCookiesDismissed = false;
                //StartPhantomJsProcess();
                CurrentDriver = StartNewRemoteWebDriver(_ipAddress, _driverPort);
                if (CurrentDriver == null)
                {
                    TestCheck.AssertFailTest("FATAL: Unable to create a new Remote WebDriver instance");
                }
                SetWebDriverTimeouts(CurrentDriver);
            }
            Helper.MsgOutput("Using HEADLESS Capabilities");
        }

        public static void SetWebDriverTimeouts(IWebDriver driver)
        {
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.PageLoad);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Script);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            driver.Manage().Window.Size = new Size(1280, 1024);
        }

        public static IWebDriver StartNewRemoteWebDriver(string ipAddress, string port)
        {
            var uri = string.Format(@"http://{0}:{1}/wd/hub", ipAddress, port);
            var capabilities = SetDesiredCapabilities();
            IWebDriver newDriver = null;
            
            try
            {
                bool portInUse = true;
                portInUse = Utils.CheckForPortInUse(ipAddress, Convert.ToInt32(port));
                Helper.MsgOutput(string.Format("INFORMATION: About to create a new RemoteWebDriver instance. Port [{0}] in use status = [{1}]", port, portInUse));
//                {
                //Helper.MsgOutput("Creating new Remote Web Driver instance with 1 minute timeout");
                //newDriver = new RemoteWebDriver(new Uri(uri), capabilities, new TimeSpan(0, 0, 1, 0));

                var headlessOptions = SetJsOptions();
                newDriver = new PhantomJSDriver(headlessOptions);
//                }
                //else
                //{
                //    if (!Utils.IsPortAvailable(ipAddress, Convert.ToInt32(port)))
                //    {
                //        Helper.MsgOutput("Unable to Connect to GhostDriver via RemoteWebDriver - Port in use");
                //        return null;
                //    }
                //}
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
                Helper.MsgOutput("Selenium stopped");
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
                BrowserCommandLineArguments = port
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

        public static int StartNewPhantomJsProcess(string ipAddress, string port)
        {
            var phantomJsProcess = new ProcessStartInfo();
            const string ignoreSsl = @" --ignore-ssl-errors=true";
            const string sslProtocol = @" --ssl-protocol=any";
            const string localToRemoteAccess = @" --local-to-remote-url-access=true";
            const string noSecurity = @" --web-security=no";
            var loggingLevel = SeleniumGlobal.Default.PhantomJSLoggingLevel;
            var logLevel = string.Format(@" --webdriver-loglevel={0}", loggingLevel); // ERROR, WARN, INFO(default), DEBUG

            var driverLog = SetDriverLog();
            var log = string.Format(@" --webdriver-logfile={0}", driverLog);
            var useRemoteWebDriver = string.Format(@" --webdriver={0}:{1}", ipAddress, port);
            phantomJsProcess.Arguments = string.Format("{0}{1}{2}{3}{4}{5}{6}", ignoreSsl, sslProtocol, noSecurity, logLevel, log, useRemoteWebDriver, localToRemoteAccess);
            phantomJsProcess.FileName = string.Format("{0}\\Drivers\\phantomJS.exe", Directory.GetCurrentDirectory());
            Helper.MsgOutput(string.Format("Starting PhantomJS for **HEADLESS** browsing [IP = {0}][Port={1}]", ipAddress, port));
            Helper.MsgOutput("With arguments ", phantomJsProcess.Arguments);
            phantomJsProcess.UseShellExecute = false;

            try
            {
                //phantomJsProcess.UserName = "EUSiteCoreTestAuto";
                //phantomJsProcess.Domain = "eu";
                //var prePassword = "Ferry1Loft2Lighter3";
                //var passwordSecure = new SecureString();
                //var passwordChars = prePassword.ToCharArray();
                //foreach (var c in passwordChars)
                //{
                //    passwordSecure.AppendChar(c);
                //}
                //phantomJsProcess.Password = passwordSecure;
                phantomJsProcess.UseShellExecute = false;

                var phantomJsProc = new Process {StartInfo = phantomJsProcess};
                var process = phantomJsProc.Start();
                if (process)
                {
                    try
                    {
                        // try and get the process by its new Id
                        Process.GetProcessById(phantomJsProc.Id);
                        return phantomJsProc.Id;
                    }
                    catch (ArgumentException)
                    {
                        Helper.MsgOutput(string.Format("Error launching PhantomJS. [{0}]", "ArgumentException thrown"));
                        return 0;
                    }
                    catch (InvalidOperationException)
                    {
                        Helper.MsgOutput(string.Format("Error launching PhantomJS. [{0}]", "InvalidOperationException thrown"));
                        return 0;
                    }
                }
            }
            catch (Win32Exception win32Exception)
            {
                Helper.MsgOutput("Error launching PhantomJS", win32Exception.Message);
            }
            return 0;
        }

        private static void StartPhantomJsProcess()
        {
            KillPhantomJsIfRunning();
            StartNewPhantomJsProcess(_ipAddress, _driverPort);
        }

        private static PhantomJSDriverService StartPhantomJsService()
        {
            KillPhantomJsIfRunning();
            
            var phantomJsService = PhantomJSDriverService.CreateDefaultService(Directory.GetCurrentDirectory() + "\\" + @"Drivers\");
            phantomJsService.IgnoreSslErrors = true;
            phantomJsService.WebSecurity = false;
            phantomJsService.AddArgument("--web-security=no");
            phantomJsService.AddArgument("--ignore-ssl-errors=yes");
            phantomJsService.AddArgument(string.Format("--webdriver={0}:{1}", _ipAddress, _driverPort));
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

        private static DesiredCapabilities SetDesiredCapabilities()
        {
            var capabilities = DesiredCapabilities.PhantomJS();
            capabilities.SetCapability("acceptSslCerts", true);
            capabilities.SetCapability("javascriptEnabled", true);
            capabilities.SetCapability("platform", "WINDOWS");
            capabilities.SetCapability("web-security", false);
            capabilities.SetCapability("ignore-sss-errors", true);
            capabilities.SetCapability("unexpectedAlertBehaviour", "accept");
            capabilities.SetCapability("browserName", "chrome");

            if (capabilities.IsJavaScriptEnabled)
            {
                Helper.MsgOutput("Driver Capabilities", "Javascript support is Enabled");
            }

            return capabilities;
        }

        private static PhantomJSOptions SetJsOptions()
        {
            var jsOptions = new PhantomJSOptions();
            jsOptions.AddAdditionalCapability("javascriptEnabled", true);
            jsOptions.AddAdditionalCapability("web-security", false);
            jsOptions.AddAdditionalCapability("ignore-sss-errors", true);
            jsOptions.AddAdditionalCapability("acceptSslCerts", true);
            jsOptions.AddAdditionalCapability("unexpectedAlertBehaviour", "accept");
            jsOptions.AddAdditionalCapability("platform", "WINDOWS");
            jsOptions.AddAdditionalCapability("browserName", "phantomjs");
            return jsOptions;
        }
    }
}
