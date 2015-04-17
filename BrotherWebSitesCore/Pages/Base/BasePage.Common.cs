using System;

using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace BrotherWebSitesCore.Pages.Base
{
    public abstract partial class BasePage : SeleniumHelper
    {
        public string BaseURL { get; set; }


        const string TestEnvSuffix = Helper.RunTimeTest;
        const string UatEnvSuffix = Helper.RunTimeUat;
        const string LiveEnvSuffix = Helper.RunTimeLive;
        const string DevEnvSuffix = Helper.RunTimeDev;

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
            if (Helper.UseCdServerDomain().ToLower().Contains("web") && !driver.Url.ToLower().Contains(Helper.UseCdServerDomain()))
            {
                driver.Url = Helper.CheckForCdServer(driver.Url);
            }
            new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));

            // Performs a second InitElements to refresh Page loading.
            PageFactory.InitElements(driver, pageInstance);

            WebDriver.Wait(Helper.DurationType.Second, 6);
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

            new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));
            PageFactory.InitElements(driver, pageInstance);
            //PageFactory.InitElements(driver, pageInstance);
            WebDriver.Wait(Helper.DurationType.Second, 5);
            return pageInstance;
        }

        #endregion
        #region Tab GetInstance

        protected TPage GetTabInstance<TPage>(IWebDriver driver = null, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            return GetTabInstance<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }

        protected static TPage GetTabInstance<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            var timeSpan = WebDriver.DefaultTimeout;
            var pageInstance = new TPage
            {
                Driver = driver,
                BaseURL = baseUrl,
            };

            PageFactory.InitElements(driver, pageInstance);
            new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));

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
            const string http = @"http://";
            if ((Helper.CheckScenarioEnv(LiveEnvSuffix) || Helper.CheckFeatureEnv(LiveEnvSuffix)) && (Helper.GetRunTimeEnv().Equals(LiveEnvSuffix)) && url.Contains("online"))
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

            var urlParts = url.ToLower().Split('.');

            if (urlParts.Length != 0)
            {
                // generally for specific brother online sites, there is a locale between Online and Brother<server>.co.uk
                // check for its existence and update accordingly. 
                // would not contain brother if locale present at this index
                if (urlParts[2].ToLower().Contains(brother))
                {
                    return string.Format("{0}.{1}.{2}.{3}", urlParts[0], Helper.Locale, urlParts[2], urlParts[3]);
                }
                // Live site at this stage so format accordingly
                if (Helper.Locale.ToUpper().Equals("UK"))
                {
                    return string.Format("{0}.{1}.co.{2}", urlParts[0], urlParts[1], Helper.Locale);
                }
                return string.Format("{0}.{1}.{2}", urlParts[0], urlParts[1], Helper.Locale);
            }
            return url;
        }

        // depending on runtime environment (e.g. Dev, Test, UAT, Production), creates a url for the correct environment
        private static string ProcessBaseUrl(string url, string env)
        {
            const string brother = @"brother";

            // check that this url does not already contain the test environment suffix 
            if (url.Contains(TestEnvSuffix) || url.Contains(UatEnvSuffix) || /*(url.Contains(TestEnvSuffix) ||*/ url.Contains(DevEnvSuffix))
            {
                return url;
            }

            return url.Replace(brother, brother + env);
        }

        private static string SetBaseUrl()
        {
            var brotherBaseHomePage = ConfigurationManager.AppSettings["BrotherOnlineHomePage_DefaultPage"];

            var runTimeEnv = Helper.GetRunTimeEnv();
            if (runTimeEnv.Equals(Helper.RunTimeLive))
            {
                return brotherBaseHomePage.Replace(".uk", string.Empty);
            }

            if (runTimeEnv.Equals(Helper.RunTimeTest))
            {
                return ProcessBaseUrl(brotherBaseHomePage, "dv2");
            }

            if (runTimeEnv.Equals(Helper.RunTimeUat))
            {
                return ProcessBaseUrl(brotherBaseHomePage, "qas");
            }
            
            if (runTimeEnv.Equals(Helper.RunTimeDev))
            {
                return ProcessBaseUrl(brotherBaseHomePage, "dev");
            }

            // for safety, always run on DV" as the default
            Helper.MsgOutput("Unable to determine BaseUrl from {0} so defaulting to DV2", runTimeEnv);
            return ProcessBaseUrl(brotherBaseHomePage, "dv2");
        }
    }
}