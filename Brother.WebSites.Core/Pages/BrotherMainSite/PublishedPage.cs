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
    public class PublishedPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a:nth-child(1)")]
        public IWebElement PageHeader;

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a.common-global-header--toggle.active")]
        public IWebElement SearchIcon;

        public void GetPublishedPage(string url)
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

        public void IsPageHeaderDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a:nth-child(1)");
              if (PageHeader == null)
                 {
                   throw new NullReferenceException("Unable to locate page header");
                 }
            AssertElementPresent(PageHeader, "Page Header", 30);            
        }

        public void IsSearchIconDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a:nth-child(1)");
            if (SearchIcon == null)
            {
                throw new NullReferenceException("Unable to locate search icon");
            }
            AssertElementPresent(SearchIcon, "Search Icon", 30);
        }

                    



    }
}
