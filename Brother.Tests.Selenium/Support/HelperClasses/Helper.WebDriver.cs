using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class WebDriver : Helper
    {
        private static TimeSpan _implicitWaitDefaultTimeout = TimeSpan.FromSeconds(80);
        private static TimeSpan _defaultTimeout = TimeSpan.FromSeconds(60);
        private const string BrowserTypeDefault = @"HL";


        public enum DefaultTimeOut
        {
            Implicit,
            PageLoad,
            Script, 
            None
        };

        public static string GetSessionInfo()
        {
            var sessionId = (string)((RemoteWebDriver)TestController.CurrentDriver).Capabilities.GetCapability("webdriver.remote.sessionid");
            return sessionId;
        }

        /// <summary>
        /// Removes all browser cookies
        /// </summary>
        public static void DeleteAllCookies()
        {
            MsgOutput("Deleting ALL Cookies for this session");
            TestController.CurrentDriver.Manage().Cookies.DeleteAllCookies();
            var allCookies = TestController.CurrentDriver.Manage().Cookies.AllCookies;
            MsgOutput("Checking if all Cookies were in fact deleted");
            if (GetCookieSize() > 0)
            {
                ShowAllCookies();
            }
        }

        public static void ShowAllCookies()
        {
            var cookies = TestController.CurrentDriver.Manage().Cookies.AllCookies;
            foreach (var cookie in cookies)
            {
                MsgOutput(string.Format("COOKIE INFO: [{0}]", cookie));                                
            }
        }

        public static int GetCookieSize()
        {
            var cookies = TestController.CurrentDriver.Manage().Cookies.AllCookies;
            return cookies.Count;
        }

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
                MsgOutput(string.Format("Unable to locate page title [{0}] due to timeout exception [{1}]", title, webDriverTimeout.Message));
                throw;
            }
        }

        public static string GetBrowserType()
        {
            return GetSpecialEnvironmentVariable("AutoTestBrowserType");
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
    }
}
