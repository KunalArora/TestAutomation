using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class MyAccountAtYourSidePage : BasePage
    {
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
            ScrollTo(AccessMpsDashboardButton);
            AccessMpsDashboardButton.Click();
            return GetInstance<TPage>(Driver);            
        }

        public TPage RedirectToMpsDashboard<TPage>(string url) where TPage : BasePage, new()
        {
            NavigateToPage(Driver, url);
            return GetInstance<TPage>(Driver);
        }

        private void IsAccessMpsDashboardButtonAvailable()
        {
            if (AccessMpsDashboardButton == null)
            {
                throw new NullReferenceException("Unable to locate Access MPS Dashboard button on page");
            }
            AssertElementPresent(AccessMpsDashboardButton, "Access MPS Dashboard button");
        }
    }
}
