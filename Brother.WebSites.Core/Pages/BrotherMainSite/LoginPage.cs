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
    public class LoginPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void GetLoginpage(string url)
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
       

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserNameTextBox;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#login > input")] 
        public IWebElement LogInButton;

        [FindsBy(How = How.Id, Using = "Main_Body")]
        public IWebElement ClickOnMainHeaderBar;

    
        public void PopulateUserNameTextBox(string userName)
        {
            UserNameTextBox.SendKeys(userName);
        }
         public void PopulatePasswordTextBox(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        public void ClickOnLoginButton(string country)
        {   
           LogInButton.Click();
        }
        public ExperienceEditorPage NavigateToExperienceEditorPage(string country)
        {
            return GetInstance<ExperienceEditorPage>(Driver, BasePage.BaseUrl, string.Empty);
        }

        public void ClickOnMainHeader(string country)
        {
            ClickOnMainHeaderBar.Click();
        }
    }
}
