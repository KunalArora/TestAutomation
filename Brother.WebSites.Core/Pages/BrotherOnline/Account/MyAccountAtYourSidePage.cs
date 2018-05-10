using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class MyAccountAtYourSidePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".common--conversion-bar--cta .btn-info";
        private const string _url = "/my-account";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }


        [FindsBy(How = How.CssSelector,
            Using =
                ".common--conversion-bar--cta a.btn-info"
            )]
        public IWebElement AccessMpsDashboardButton;

        public MyAccountAtYourSidePage()
        {
            
        }

        public TPage ClickAccessMpsDashboardButtonToDashboard<TPage>() where TPage : BasePage, new()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(AccessMpsDashboardButton);
            AccessMpsDashboardButton.Click();
            return GetInstance<TPage>(Driver);            
        }

        public TPage RedirectToMpsDashboard<TPage>(string url) where TPage : BasePage, new()
        {
            LoggingService.WriteLogOnMethodEntry(url);
            NavigateToPage(Driver, url);
            return GetInstance<TPage>(Driver);
        }

        private void IsAccessMpsDashboardButtonAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AccessMpsDashboardButton == null)
            {
                throw new NullReferenceException("Unable to locate Access MPS Dashboard button on page");
            }
            AssertElementPresent(AccessMpsDashboardButton, "Access MPS Dashboard button");
        }
    }
}
