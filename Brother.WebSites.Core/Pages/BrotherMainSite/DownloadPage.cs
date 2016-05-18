using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class DownloadPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
        
        [FindsBy(How = How.CssSelector, Using = ".common-global-header--title")]
        public IWebElement PageTitle;

        public void GetDownloadPage(string url)
        {
            TestCheck.AssertIsEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code returned");
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));
            return responseCode;
        }

        public void VerifyPageTitleExist()
        {
            WaitForElementToExistByCssSelector(".common-global-header--title");
            if (PageTitle == null)
            {
                throw new NullReferenceException("Unable to locate rich text module");
            }

        }

        public bool VerifyPageTitleExists(int retry, int timeToWait)
        {
            try
            {
                if (WaitForElementToExistByCssSelector(".common-global-header--title", retry, timeToWait))
                {
                    var pageTitle =
                        Driver.FindElement(By.CssSelector(".common-global-header--title"));
                    if (pageTitle != null)
                    {
                        if (pageTitle.Displayed)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Title does not exist [{0}]", elementNotVisible.Message));
            }
            return false;
        }

    }
}
