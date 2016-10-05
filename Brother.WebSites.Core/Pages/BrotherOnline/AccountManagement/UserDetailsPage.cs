using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Online.TestSpecs._80.Test_Steps
{
    [Binding]
    public class UserDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void GetUserDetailsPage(string url)
        {
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(60));
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

        [FindsBy(How = How.Name, Using = "EmailAddress")]
        public IWebElement EmailIdInputField;

        public void EnterEmailId(string emailid)
        {
            EmailIdInputField.SendKeys(emailid);
        }

        
        
    }
}
