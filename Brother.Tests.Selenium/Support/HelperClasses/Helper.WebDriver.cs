using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class WebDriver : Helper
    {
        private static TimeSpan _implicitWaitDefaultTimeout = TimeSpan.FromSeconds(80);
        private static TimeSpan _defaultTimeout = TimeSpan.FromSeconds(60);
        private const string BrowserTypeDefault = @"HL";

        private static WebDriverPackage _webDriverPackage;

        public enum DefaultTimeOut
        {
            Implicit,
            PageLoad,
            Script, 
            None
        };

        //public void TouchScreen(TouchActions action)
        //{
        //    action.Flick()
        //}

        public static TimeSpan SetWebDriverImplicitTimeout(TimeSpan timeout)
        {
            TestController.CurrentDriver.Manage().Timeouts().ImplicitlyWait(timeout);
            // returns default
            return _implicitWaitDefaultTimeout;
        }

        public static void SetWebDriverDefaultTimeOuts(DefaultTimeOut defaultTimeOut)
        {
            switch (defaultTimeOut)
            {
                case DefaultTimeOut.Implicit:
                    SetWebDriverImplicitTimeout(ImplicitWaitDefaultTimeout);
                    break;

                case DefaultTimeOut.PageLoad:
                    SetPageLoadTimeout(DefaultTimeout);
                    break;

                case DefaultTimeOut.Script:
                    SetScriptTimeout(DefaultTimeout);
                    break;
            }
        }

        public static void SetPageLoadTimeout(TimeSpan timeout)
        {
            TestController.CurrentDriver.Manage().Timeouts().SetPageLoadTimeout(timeout);
        }

        public static void SetScriptTimeout(TimeSpan timeout)
        {
            TestController.CurrentDriver.Manage().Timeouts().SetScriptTimeout(timeout);
        }

        public static TimeSpan DefaultTimeout
        {
            get { return _defaultTimeout; }
            set { _defaultTimeout = value; }
        }

        public static TimeSpan ImplicitWaitDefaultTimeout
        {
            get { return _implicitWaitDefaultTimeout; }
            set { _implicitWaitDefaultTimeout = value; }
        }

        public static void WaitForTitle(IWebDriver driver, string title, TimeSpan timeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, timeout).Until((d) => d.Title == title);
            }
            catch (WebDriverTimeoutException webDriverTimeout)
            {
                MsgOutput("Unable to locate page title", title);
                throw;
            }
        }

        public static string GetBrowserType()
        {
            return Environment.GetEnvironmentVariable("AutoTestBrowserType", EnvironmentVariableTarget.Machine);
        }

        public static bool SetBrowserType(string browserType)
        {
            var browser = GetBrowserType();
            if (browser != null && browser.Equals(browserType))
            {
                return true;
            }
            Environment.SetEnvironmentVariable("AutoTestBrowserType", browserType, EnvironmentVariableTarget.Machine);
            return GetBrowserType().Equals(browserType);
        }


        /// <summary>
        /// Waits the specified duration.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="duration">The duration.</param>
        // Duplicate of similar method in Common but requried
        public static void Wait(Helper.DurationType durationType, int duration)
        {
            switch (durationType)
            {
                case DurationType.Millisecond:
                    Thread.Sleep(TimeSpan.FromMilliseconds(duration));
                    break;
                case DurationType.Second:
                    Thread.Sleep(TimeSpan.FromSeconds(duration));
                    break;
                case DurationType.Minute:
                    Thread.Sleep(TimeSpan.FromMinutes(duration));
                    break;
            }
        }

        public static IWebDriver LaunchNewDriverWindow()
        {
            IWebDriver newDriver;
            var phantomJsId = -1;

            if (TestController.IsHeadlessRunning)
            {
                phantomJsId = TestController.StartNewPhantomJsProcess("127.0.0.5", "6666");
                newDriver = TestController.StartNewRemoteWebDriver("127.0.0.5", "6666");
                TestController.SetWebDriverTimeouts(newDriver);
            }
            else
            {
                newDriver = new ChromeDriver();
                TestController.SetWebDriverTimeouts(newDriver);
            }
            SetWebDriverPackage(newDriver, phantomJsId);
            return newDriver;
        }

        /// <summary>
        /// Clears down the current instance of the WebDriverPackage
        /// </summary>
        public static void ClearWebDriverPackage()
        {
            if (_webDriverPackage != null)
            {
                _webDriverPackage.Driver.Close();
                _webDriverPackage.Driver.Quit();
                if (_webDriverPackage.HeadlessProcess != -1)
                {
                    TestController.KillPhantomJs(_webDriverPackage.HeadlessProcess);
                }
            }

            _webDriverPackage = null;
        }

        /// <summary>
        /// Sets the webDriverPackage instance values.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="processId"></param>
        private static void SetWebDriverPackage(IWebDriver driver, int processId)
        {
            _webDriverPackage = new WebDriverPackage();
            _webDriverPackage.Driver = driver;
            _webDriverPackage.HeadlessProcess = processId;
        }
    }
}
