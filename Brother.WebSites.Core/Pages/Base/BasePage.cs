using System;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using Brother.WebSites.Core.Pages.BrotherOnline.DataManager;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.OmniJoin;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.Base
{
    public abstract partial class BasePage
    {
        public static string BaseUrl
        {
            get { return SetBaseUrl(); }
            
        }

        // Home pages
        #region WebConferencing Home Page
        
        public static WebConferencingHomePage LoadWebConferencingHomePage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + WebConferencingHomePage.URL);
            return GetInstance<WebConferencingHomePage>(driver, baseUrl, "");
        }

        #endregion

        public static MainSiteHomePage LoadBrotherMainSiteHomePage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            baseUrl = CheckForCdServer(baseUrl); 
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<MainSiteHomePage>(driver, baseUrl, "");
        }

        public static LoginPage LoadBrotherMainSiteLoginPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<LoginPage>(driver, baseUrl, "");
        }
        public static DataManagerPage LoadDataManagerPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<DataManagerPage>(driver, baseUrl, "");
        }
        public static PublishedPage LoadPublishedPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<PublishedPage>(driver, baseUrl, "");
        }

        public static ExperienceEditorPage LoadExperienceEditorPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<ExperienceEditorPage>(driver, baseUrl, "");
        }

        public static ContentEditorPage LoadContentEditorPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<ContentEditorPage>(driver, baseUrl, "");
        }

        public static FooterNavigationPage LoadFooterPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<FooterNavigationPage>(driver, baseUrl, "");
        }

        public static HeaderNavigationPage LoadHeaderPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<HeaderNavigationPage>(driver, baseUrl, "");
        }

        #region ThirdParty Pages 
        public static BrotherEmailConfirmationPage LoadEmailConfirmationPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            
            // Email Token Test pages use a cms part in the URL
            baseUrl = baseUrl.Replace("online.uk.", "");
            baseUrl = baseUrl.Replace("brother", "cms.brother");
            baseUrl = baseUrl.Replace("online.", "");
            baseUrl = baseUrl.Replace("brother.co.uk", "brother.eu");
            CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + BrotherEmailConfirmationPage.Url);
            return GetInstance<BrotherEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static MailinatorEmailConfirmationPage LoadMailinatorEmailConfirmationPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + MailinatorEmailConfirmationPage.Url + Email.EmailSuffix);
            return GetInstance<MailinatorEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static GuerillaEmailConfirmationPage LoadGuerrillaEmailInboxPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + GuerillaEmailConfirmationPage.Url, true);
            return GetInstance<GuerillaEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static RegistrationPage ValidateBrotherOnlineEmailConfirmationUrl(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<RegistrationPage>(driver, baseUrl, "");
        }

        #endregion

        #region Brother Online Home Page

        public static HomePage LoadBolHomePage(IWebDriver driver, string baseUrl, string defaultTitleOverride)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = CheckForCdServer(baseUrl);
            CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + MainSiteHomePage.Url);
            return GetInstance<HomePage>(driver, baseUrl, defaultTitleOverride);
        }

        public static HomePage LoadWebBoxes(IWebDriver driver, string baseUrl, string defaultTitleOverride)
        {
            driver = SetDriver(driver);
            driver.Navigate().GoToUrl(baseUrl);
            return GetInstance<HomePage>(driver, baseUrl, defaultTitleOverride);
        }

        // Specific to Email Token validation. Need to Switch to separate tab due to Email Validation page
        // taking presidence
        public static RegistrationPage LoadSignInPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            if (driver.WindowHandles.Count > 1)
            {
                var currentWindowHandle = driver.CurrentWindowHandle;

                foreach (var winHandle in driver.WindowHandles.Where(winHandle => currentWindowHandle != winHandle))
                {
                    // Kill old tab
                    driver.SwitchTo().Window(currentWindowHandle).Close();
                    // Switch to new window
                    driver = driver.SwitchTo().Window(winHandle);
                }
            }
            baseUrl = CheckForCdServer(baseUrl);
            CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<RegistrationPage>(driver, baseUrl, "");
        }

        #endregion Home Page

        #region "Credit Card Details Frame"
        public static CreditCardDetailsPage LoadCreditCardDetailsFrame(IWebDriver driver)
        {
            driver = SetDriver(driver);
            MsgOutput("Loading Credit Card details frame");
            return GetIFrameInstance<CreditCardDetailsPage>(driver, "", "");
        }
        #endregion

        private static IWebDriver SetDriver(IWebDriver driver)
        {
            return driver ?? TestController.CurrentDriver;
        }

        public static void NavigateToPage(IWebDriver driver, string url)
        {
            try
            {
                MsgOutput("Attempting to navigate to page ", url);
                NavigateToUrl(driver, url);
                MsgOutput(string.Format("Browser is on Page {0}", url));
                AcceptCookieLaw(driver);
            }
            catch (WebDriverException driverException)
            {
                MsgOutput(string.Format("Web Driver Critical Error!!!! {0}", driverException.Message));
                MsgOutput(string.Format("Likelihood that WebDriver could not get to the URL {0}", url));
            }
        }

        private static void NavigateToPage(IWebDriver driver, string url, bool doRefresh)
        {
            try
            {
                MsgOutput("Attempting to navigate to page ", url);
                NavigateToUrl(driver, url);
                if (doRefresh)
                {
                    driver.Navigate().Refresh();
                }
                MsgOutput(string.Format("Browser is on Page {0}", url));
                AcceptCookieLaw(driver);
            }
            catch (WebDriverException driverException)
            {
                MsgOutput(string.Format("Web Driver Critical Error!!!! {0}", driverException.Message));
                MsgOutput(string.Format("Likelhood that WebDriver could not get to the URL {0}", url));
            }
        }

        private static void NavigateToUrl(IWebDriver driver, string url)
        {
            var timedOut = false;
            var retries = 0;

            var currentPageSource = driver.PageSource;

            driver.Navigate().GoToUrl(url);
            while ((driver.PageSource == currentPageSource) && (!timedOut))
            {
                try
                {
                    WebDriver.Wait(DurationType.Second, 3);
                    retries++;
                    if (retries == 60)
                    {
                        timedOut = true;
                    }
                }
                catch (WebDriverException driverException)
                {
                    MsgOutput(string.Format("Web Driver Critical Error!!!! {0}", driverException.Message));
                    MsgOutput(string.Format("Likelhood that WebDriver could not get to the URL {0}", url));
                    MsgOutput(string.Format("Attempting a retry....Retry {0} times", retries));
                }
            }
            MsgOutput(string.Format("Current WebDriver [driver.URL] value is [{0}]. Actual desired URL (the one we want) should be [{1}]", driver.Url, url));
            TestCheck.AssertIsEqual(true, (currentPageSource != driver.PageSource), string.Format("Page Source Mismatch - could not navigate to URL {0} and the page source differences reflect this", url));
        }
    }
}
