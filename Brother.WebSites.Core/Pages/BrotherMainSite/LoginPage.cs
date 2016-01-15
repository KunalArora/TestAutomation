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

        [FindsBy(How = How.XPath, Using = ".//*[@id='login']/input")] 
        public IWebElement LogInButton;

        [FindsBy(How = How.Id, Using = "Main_Body")]
        public IWebElement ClickOnMainHeaderBar;

        [FindsBy(How = How.CssSelector, Using = ".scInsertionHandle")] 
        public IWebElement ClickOnAddHereButton;

        [FindsBy(How = How.CssSelector, Using = "#I5D6D39F4FE9549C0AAF4DF8A5B9F880B > div > img")]
        public IWebElement ClickOnGridContentOneColumnGrid;

        [FindsBy(How = How.XPath, Using = ".//*[@id='OpenPropertiesBorder']")]
        public IWebElement ClickOnSelectRendering ;

        [FindsBy(How = How.CssSelector, Using = "#body > header > div > div > a:nth-child(1)")]
        public IWebElement PageHeader;
    
        public void PopulateUserNameTextBox(string userName)
        {
            UserNameTextBox.SendKeys(userName);
        }
         public void PopulatePasswordTextBox(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

         public ExperienceEditorPage ClickOnLoginButton(string country)
        {   
             LogInButton.Click();
             return GetInstance<ExperienceEditorPage>();
        }
        public ExperienceEditorPage NavigateToExperienceEditorPage(string country)
        {
            return GetInstance<ExperienceEditorPage>(Driver, BasePage.BaseUrl, string.Empty);
        }

        public void ClickOnMainHeader(string country)
        {
            ClickOnMainHeaderBar.Click();
        }

        public void ClickOnAddHere(string country)
        {
            ClickOnAddHereButton.Click();
        }

        public void ClickOnGrid(string country)
        {
            ClickOnGridContentOneColumnGrid.Click();
        }

        public void ClickOnSelectRenderingWindow(string country)
        {
            ClickOnSelectRendering.Click();
        }

        public void IsPageHeaderDisplayed()
        {
            if (PageHeader == null)
            {
              throw new NullReferenceException("Unable to locate page header");
            }         
            AssertElementPresent(PageHeader, "Page Header", 80);
        }
    }
}
