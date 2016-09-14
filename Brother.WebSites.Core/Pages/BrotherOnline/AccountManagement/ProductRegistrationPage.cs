
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

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class ProductRegistrationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = @"div.common-global-header--title > a > img")]
        public IWebElement BrotherLogo;

        [FindsBy(How = How.CssSelector, Using = @"footer .row.common-global-footer--row .col-sm-9.col-lg-9 > ul > li")]
        public IWebElement FooterLinks;

        [FindsBy(How = How.CssSelector, Using = "#serial-number")]
        public IWebElement SerialNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement FindProductButton;

        public void GetProductRegistrationPage(string url)
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
        
        public void CheckForHeaderAndFooter()
        {
            //Checks for the existance of elements on Header and Footer
            AssertElementPresent(BrotherLogo, "Brother Logo missing in the Header");
            AssertElementPresent(FooterLinks, "Fotter Links missing on the landing page");
        }
        
        public void PopulateSerialNumberTextBox(string serialnumber)
        {

            SerialNumberTextBox.SendKeys(serialnumber);
        }

        public void ClickFindProductButton()
        {
            FindProductButton.Click();
        }



    }
}
