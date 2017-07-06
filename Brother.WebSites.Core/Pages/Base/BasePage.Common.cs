using System;
using System.Configuration;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Brother.Tests.Selenium.Lib.Properties;

namespace Brother.WebSites.Core.Pages.Base
{
    public abstract partial class BasePage : SeleniumHelper
    {
        public string BaseURL { get; set; }


        const string TestEnvSuffix = RunTimeTest;
        const string UatEnvSuffix = RunTimeUat;
        const string LiveEnvSuffix = RunTimeLive;
        const string DevEnvSuffix = RunTimeDev;

        public virtual string DefaultTitle
        {
            get { return ""; }
        }


        #region Base GetInstance()
        public TPage GetInstance<TPage>(IWebDriver driver = null, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }

        public static TPage GetInstance<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            var timeSpan = WebDriver.DefaultTimeout;
            var pageInstance = new TPage
            {
                Driver = driver,
                BaseURL = baseUrl

            };
            if (UseCdServerDomain().ToLower().Contains("web") && !driver.Url.ToLower().Contains(UseCdServerDomain()))
            {
                driver.Url = CheckForCdServer(driver.Url);
            }

            try
            {
                new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));
            }
            catch (TimeoutException timeOut)
            {
                MsgOutput("FATAL: (GetInstance<TPage>) Waiting for body tag element to appear on Page. This can be due to the current test not being on the correct page");
            }

            // Initialise the page instance with elements based on FindsBy entries
            PageFactory.InitElements(driver, pageInstance);

            // Small wait for page to complete loading. Poor but required at this time (increase to 6 seconds if issues discovered)
            WebDriver.Wait(DurationType.Second, 6);

            return pageInstance;
        }
        #endregion
        #region IFrame GetInstance()
        protected TPage GetIFrameInstance<TPage>(IWebDriver driver = null, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            return GetIFrameInstance<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }

        protected static TPage GetIFrameInstance<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            var timeSpan = WebDriver.DefaultTimeout;
            
            var pageInstance = new TPage
            {
                Driver = driver,
                BaseURL = baseUrl
            };

            try
            {
                new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));
            }
            catch (WebDriverException timeOutDriverException)
            {
                MsgOutput(string.Format("Exception was [{0}]", timeOutDriverException));
                TestCheck.AssertFailTest("Unable to get IFrame Instance. WebDriver timed out");
            }

            PageFactory.InitElements(driver, pageInstance);
            // Small wait for page to sort itself out
            WebDriver.Wait(DurationType.Second, 6);
            return pageInstance;
        }

        #endregion
        #region Tab GetInstance

        protected TPage GetTabInstance<TPage>(IWebDriver driver = null)
            where TPage : BasePage, new()
        {
            return GetTabInstance<TPage>(driver ?? Driver, BaseURL);
        }

        protected static TPage GetTabInstance<TPage>(IWebDriver driver, string baseUrl, bool assertUrlHasChanged = false)
            where TPage : BasePage, new()
        {
            var initialUrl = driver.Url;
            var timeSpan = WebDriver.DefaultTimeout;
            var pageInstance = new TPage
            {
                Driver = driver,
                BaseURL = baseUrl,
            };

            PageFactory.InitElements(driver, pageInstance);
            new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));

            var finalUrl = driver.Url;

            if (assertUrlHasChanged)
                TestCheck.AssertIsEqual(false, initialUrl.Equals(finalUrl), 
                    String.Format("{0} did not redirected to expected new page", initialUrl));

            return pageInstance;
        }
        #endregion


     
        /// <summary> 
        /// Asserts that the current page is of the given type 
        /// </summary> 
        public void Is<TPage>() where TPage : BasePage, new()
        {
            if (!(this is TPage))
            {
                TestCheck.AssertFailTest(string.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        /// <summary> 
        /// Inline cast to the given page type 
        /// </summary> 
        public TPage As<TPage>() where TPage : BasePage, new()
        {
            return (TPage)this;
        }

        private static string ProcessMainSiteLiveUrl(string url)
        {
            if ((CheckScenarioEnv(LiveEnvSuffix) || CheckFeatureEnv(LiveEnvSuffix)) && (GetRunTimeEnv().Equals(LiveEnvSuffix)) && url.Contains("online"))
            {
               return url.Replace("online.", "www.");
            }
            // none live site so just replace "online"
            return url.Replace("online.", string.Empty);
        }

        // depending on locale, correctly produces the locale url for the given url
        private static string ProcessUrlLocale(string url)
        {
            const string brother = @"brother";
            const string mainUrl = "main";
            const string local = @".local";
            
            var urlParts = url.ToLower().Split('.');
            
            if (url.ToLower().Contains(local)) return url;
            if (urlParts.Length == 0) return url;

            if (urlParts[1].ToLower().Contains(brother))
            {
                if(Locale.ToUpper().Equals("UK"))
                    url = url.Replace("eu", "co.uk");
                else
                    url = url.Replace("eu", Locale);
                return url.Replace("main.", "online.");
            }

            //if (urlParts[0].ToLower().Contains(mainUrl)) return url;
            // generally for specific brother online sites, there is a locale between Online and Brother<server>.co.uk
            // check for its existence and update accordingly.
            // would not contain brother if locale present at this index
            
            if (urlParts[2].ToLower().Contains(brother))
            {
                return string.Format("{0}.{1}.{2}.{3}", urlParts[0], Locale, urlParts[2], urlParts[3]);
            }

            if (urlParts[3].ToLower().Contains(brother))
            {
                if (Locale.ToUpper().Equals("UK"))
                    return url;
                return string.Format("{0}.{1}.{2}.{3}", urlParts[0], Locale, urlParts[3], urlParts[4]);
            }

            // Live site at this stage so format accordingly
            if (Locale.ToUpper().Equals("UK"))
            {
                return string.Format("{0}.{1}.co.{2}", urlParts[0], urlParts[1], Locale);
            }

            return string.Format("{0}.{1}.{2}", urlParts[0], urlParts[1], Locale);
        }

        // depending on runtime environment (e.g. Dev, Test, UAT, Production), creates a url for the correct environment
        private static string ProcessBaseUrl(string url, string env)
        {
            const string brother = @"brother";

            // check that this url does not already contain any environment suffix
            if (url.Contains(TestEnvSuffix) || url.Contains(UatEnvSuffix) || url.Contains(DevEnvSuffix))
            {
                return url;
            }

            return url.Replace(brother, brother + env);
        }

        private static string SetBaseUrl1()
        {
            var brotherBaseHomePage = ConfigurationManager.AppSettings["BrotherOnlineHomePage_DefaultPage"];

            const string mainUrl = "main"; 

            var urlParts = brotherBaseHomePage.ToLower().Split('.');

            var runTimeEnv = GetRunTimeEnv();

            if (runTimeEnv.Equals(RunTimeLive) && !urlParts[0].ToLower().Contains(mainUrl))
            {
                return brotherBaseHomePage.Replace(".uk", string.Empty);
            }

            if (runTimeEnv.Equals(RunTimeLive) && urlParts[0].ToLower().Contains(mainUrl))
            {
                //return brotherBaseHomePage;
                return brotherBaseHomePage.Replace(".co.uk.cms", string.Empty);
            }

            if (runTimeEnv.Equals(RunTimeTest) && !urlParts[0].ToLower().Contains(mainUrl))
            {
                return ProcessBaseUrl(brotherBaseHomePage, "dv2");
            }

            if (runTimeEnv.Equals(RunTimeTest) && urlParts[0].ToLower().Contains(mainUrl))
            {
                return ProcessBaseUrl(brotherBaseHomePage.Replace(".cms", string.Empty), "dv2");
            }

            if (runTimeEnv.Equals(RunTimeUat))
            {
               // return "http://online.brother.co.uk.local";
                return ProcessBaseUrl(brotherBaseHomePage, "qas");
            }
            
            if (runTimeEnv.Equals(RunTimeDev))
            {
                return ProcessBaseUrl(brotherBaseHomePage, "dev");
            }

            //if (runTimeEnv.Equals("LOCAL"))
            //{
            //    return "http://online.brother.co.uk.local";
            //}

            // for safety, always run on DV" as the default
            MsgOutput("Unable to determine BrotherOnlineBaseUrl from {0} so defaulting to DV2", runTimeEnv);
            return ProcessBaseUrl(brotherBaseHomePage, "dv2");
        }


        private static string SetMainSiteBaseUrl()
        {
            var env = GetRunTimeEnv();
            string url;

            switch (env)
            {
                case "TEST":
                    url = SeleniumGlobal.Default.MainSiteTest;
                    break;
                case "UAT":
                    url = SeleniumGlobal.Default.MainSiteUAT;
                    break;
                default:
                    url = SeleniumGlobal.Default.MainSiteTest;
                    break;
            }

            var locale = Locale.ToLower().Equals("uk") ? "co.uk" : Locale;

            url = String.Format(url, locale);

            return url;
        }

        public static string SetBrotherOnlineBaseUrl()
        {
            var env = GetRunTimeEnv();
            string url;

            switch (env)
            {
                case "TEST" :
                    url = SeleniumGlobal.Default.TestUrl65;
                    break;
                case "UAT":
                    url = SeleniumGlobal.Default.QASUrl65;
                    break;
                default:
                    url = SeleniumGlobal.Default.TestUrl65;
                    break;
            }

            var locale = Locale.ToLower().Equals("uk") ? "co.uk" : Locale;

            url = String.Format(url, locale);

            return url;
        }
    }
}
