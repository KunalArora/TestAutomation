using System;
using System.Linq;
using Brother.Online.TestSpecs._80.Test_Steps;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.OmniJoin;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.Base
{
    public abstract partial class BasePage
    {
        public static string BrotherOnlineBaseUrl
        {
            get { return SetBrotherOnlineBaseUrl(); }
            
        }

        public static string MainSiteBaseUrl
        {
            get { return SetMainSiteBaseUrl(); }

        }

        // Home pages
        #region WebConferencing Home Page
        
        public static WebConferencingHomePage LoadWebConferencingHomePage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            //baseUrl = ProcessUrlLocale(baseUrl);
            //baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            //baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }) + WebConferencingHomePage.URL);
            return GetInstance<WebConferencingHomePage>(driver, baseUrl, "");
        }

        #endregion

        #region BrotherMainSite Home Page

        public static MainSiteHomePage LoadBrotherMainSiteHomePage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            //baseUrl = ProcessUrlLocale(baseUrl);
            //baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            //baseUrl = CheckForCdServer(baseUrl); 
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<MainSiteHomePage>(driver, baseUrl, "");
        }

        #endregion

        #region BrotherOnline Home Page

        public static HomePage LoadBrotherOnlineHomePage(IWebDriver driver, string country)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, BrotherOnlineBaseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<HomePage>(driver, BrotherOnlineBaseUrl, "");
        }

        #endregion

        #region BrotherMainSite Login Page

        public static LoginPage LoadBrotherMainSiteLoginPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            //var url = ProcessUrlLocale(BrotherOnlineBaseUrl);
            var url = BrotherOnlineBaseUrl;
            NavigateToPageSitecore(driver, url + baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<LoginPage>(driver, baseUrl, "");
        }

        #endregion

        public static PublishedPage LoadPublishedPage(IWebDriver driver, string baseUrl)
        {
           driver = SetDriver(driver);
           NavigateToPage(driver, BrotherOnlineBaseUrl+baseUrl.TrimEnd(new[] { '/' }));
           return GetInstance<PublishedPage>(driver, baseUrl, "");
        }

        public static CheckoutPage LoadMainSiteHomePage(IWebDriver driver, string baseUrl)
        {
           driver = SetDriver(driver);
           NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
           return GetInstance<CheckoutPage>(driver, baseUrl, "");
        }

       public static DownloadPage LoadDownloadPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<DownloadPage>(driver, baseUrl, "");
        }
        public static ExperienceEditorPage LoadExperienceEditorPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPageSitecore(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<ExperienceEditorPage>(driver, baseUrl, "");
        }

        public static ContentEditorPage LoadContentEditorPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPageSitecore(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<ContentEditorPage>(driver, baseUrl, "");
        }

        public static FooterNavigationPage LoadFooterPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            //baseUrl = ProcessUrlLocale(baseUrl);
            //baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            //baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<FooterNavigationPage>(driver, baseUrl, "");
        }

        public static HeaderNavigationPage LoadHeaderPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            //baseUrl = ProcessUrlLocale(baseUrl);
            //baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            //baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<HeaderNavigationPage>(driver, baseUrl, "");
        }


        public static ProductRegistrationPage LoadProductRegistrationPage(IWebDriver driver, string baseUrl = null)
        {
            driver = SetDriver(driver);
            //NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new char[] { '/' }));
            if (baseUrl == null)
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl.TrimEnd(new[] { '/' }));
            }
            else
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new[] { '/' }));
            }
            return GetInstance<ProductRegistrationPage>(driver, baseUrl, "");
        }

        public static BasketPage LoadBasketPage(IWebDriver driver, string baseUrl = null)
        {
            driver = SetDriver(driver);
            //NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new char[] { '/' }));
            if (baseUrl == null)
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl.TrimEnd(new[] { '/' }));
            }
            else
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new[] { '/' }));
            }
            return GetInstance<BasketPage>(driver, baseUrl, "");
        }



        public static SignInPage LoadSignPage(IWebDriver driver, string baseUrl = null)
        {
            driver = SetDriver(driver);
            //NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new char[] { '/' }));
            if (baseUrl == null)
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl.TrimEnd(new[] { '/' }));
            }
            else
            {
                NavigateToPage(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new[] { '/' }));
            }
            

            return GetInstance<SignInPage>(driver, baseUrl, "");
        }

        public static UserDetailsPage LoadUserDetailsPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPageSitecore(driver, BrotherOnlineBaseUrl + baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<UserDetailsPage>(driver, baseUrl, "");
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
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }) + BrotherEmailConfirmationPage.Url);
            return GetInstance<BrotherEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static MailinatorEmailConfirmationPage LoadMailinatorEmailConfirmationPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }) + MailinatorEmailConfirmationPage.Url + Email.EmailSuffix);
            return GetInstance<MailinatorEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static GuerillaEmailConfirmationPage LoadGuerrillaEmailInboxPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }) + GuerillaEmailConfirmationPage.Url, true);
            return GetInstance<GuerillaEmailConfirmationPage>(driver, baseUrl, "");
        }

        public static RegistrationPage ValidateBrotherOnlineEmailConfirmationUrl(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
            return GetInstance<RegistrationPage>(driver, baseUrl, "");
        }

        #endregion

        #region Brother Online Home Page

        public static HomePage LoadBolHomePage(IWebDriver driver, string baseUrl, string defaultTitleOverride)
        {
            driver = SetDriver(driver);
            //baseUrl = ProcessUrlLocale(baseUrl);
            //baseUrl = CheckForCdServer(baseUrl);
            CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }) + MainSiteHomePage.Url);
            //driver.Navigate().GoToUrl(baseUrl);
            return GetInstance<HomePage>(driver, baseUrl, defaultTitleOverride);
        }

        public static HomePage LoadWebBoxes(IWebDriver driver, string baseUrl, string defaultTitleOverride)
        {
            driver = SetDriver(driver);
            driver.Navigate().GoToUrl(baseUrl);
            return GetInstance<HomePage>(driver, BrotherOnlineBaseUrl + baseUrl, defaultTitleOverride);
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
           // baseUrl = CheckForCdServer(baseUrl);
            CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new[] { '/' }));
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

        public static void NavigateToPageSitecore(IWebDriver driver, string url)
        {
            try
            {
                MsgOutput("Attempting to navigate to page ", url);
                NavigateToUrl(driver, url);
                MsgOutput(string.Format("Browser is on Page {0}", url));

            }
            catch (WebDriverException driverException)
            {
                MsgOutput(string.Format("Web Driver Critical Error!!!! {0}", driverException.Message));
                MsgOutput(string.Format("Likelihood that WebDriver could not get to the URL {0}", url));
            }
        }

        private static void NavigateToPageSitecore(IWebDriver driver, string url, bool doRefresh)
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
