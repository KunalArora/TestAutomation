using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.BrotherMainSite;
using BrotherWebSitesCore.Pages.BrotherOnline.Account;
using BrotherWebSitesCore.Pages.BrotherOnline.Checkout;
using BrotherWebSitesCore.Pages.BrotherOnline.ThirdParty;
using BrotherWebSitesCore.Pages.MPSTwo;
using BrotherWebSitesCore.Pages.OmniJoin;
using OpenQA.Selenium;

namespace BrotherWebSitesCore.Pages.Base
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
            baseUrl = Helper.CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + WebConferencingHomePage.URL);
            return GetInstance<WebConferencingHomePage>(driver, baseUrl, "");
        }

        #endregion

        public static MainSiteHomePage LoadBrotherMainSiteHomePage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = ProcessMainSiteLiveUrl(baseUrl);
            baseUrl = Helper.CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<MainSiteHomePage>(driver, baseUrl, "");
        }

        #region MPS Home Page

        public static CloudExistingProposalPage LoadMpsLandingPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            driver.Navigate().GoToUrl(baseUrl.TrimEnd(new char[] { '/' }) + CloudExistingProposalPage.URL);
            return GetTabInstance<CloudExistingProposalPage>(driver, baseUrl, "");
        }

        #endregion

        #region ThirdParty Pages
        public static BrotherEmailConfirmationPage LoadEmailConfirmationPage(IWebDriver driver, string baseUrl)
        {
            driver = SetDriver(driver);
            
            // Email Token Test pages use a cms part in the URL
            baseUrl = baseUrl.Replace("online.uk.", "");
            baseUrl = baseUrl.Replace("brother", "cms.brother");
            baseUrl = baseUrl.Replace("online.", "");
            baseUrl = baseUrl.Replace("brother.co.uk", "brother.eu");
            Helper.CurrentDomain = baseUrl;
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
            baseUrl = Helper.CheckForCdServer(baseUrl);
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<RegistrationPage>(driver, baseUrl, "");
        }

        #endregion

        #region Brother Online Home Page

        public static HomePage LoadBolHomePage(IWebDriver driver, string baseUrl, string defaultTitleOverride)
        {
            driver = SetDriver(driver);
            baseUrl = ProcessUrlLocale(baseUrl);
            baseUrl = Helper.CheckForCdServer(baseUrl);
            Helper.CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }) + MainSiteHomePage.Url);
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

                foreach (var winHandle in driver.WindowHandles)
                {
                    if (currentWindowHandle != winHandle)
                    {
                        // Kill old tab
                        driver.SwitchTo().Window(currentWindowHandle).Close();
                        // Switch to new window
                        driver = driver.SwitchTo().Window(winHandle);
                    }
                }
            }
            baseUrl = Helper.CheckForCdServer(baseUrl);
            Helper.CurrentDomain = baseUrl;
            NavigateToPage(driver, baseUrl.TrimEnd(new char[] { '/' }));
            return GetInstance<RegistrationPage>(driver, baseUrl, "");
        }

        #endregion Home Page

        #region "Credit Card Details Frame"
        public static CreditCardDetailsPage LoadCreditCardDetailsFrame(IWebDriver driver)
        {
            driver = SetDriver(driver);
            Helper.MsgOutput("Loading Credit Card details frame");
            return GetIFrameInstance<CreditCardDetailsPage>(driver, "", "");
        }
        #endregion

        private static IWebDriver SetDriver(IWebDriver driver)
        {
            // Note: If this does not work as expected, you will need to add a reference to the BasePage.Bindings..... dll
            // so that you can access Browser.Current
         //   return driver ?? Browser.Current;
            return driver ?? TestController.CurrentDriver;
        }

        private static void NavigateToPage(IWebDriver driver, string url)
        {
            Helper.MsgOutput("Attempting to navigate to page ", url);
            driver.Navigate().GoToUrl(url);
        }

        private static void NavigateToPage(IWebDriver driver, string url, bool doRefresh)
        {
            Helper.MsgOutput("Attempting to navigate to page ", url);
            driver.Navigate().GoToUrl(url);
            if (doRefresh)
            {
                driver.Navigate().Refresh();
            }
        }
    }
}
