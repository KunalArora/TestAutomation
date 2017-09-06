using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class AtYourSideHomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".common-global-header--items .fa-user")]
        public IWebElement MyAccountLink;

        public void IsMyAccountLinkAvailable()
        {
            if (MyAccountLink == null)
            {
                throw new NullReferenceException("Unable to locate my account link on page");
            }
            AssertElementPresent(MyAccountLink, "My account link");
        }

        public SignInAtYourSidePage ClickMyAccountLink()
        {
            ScrollTo(MyAccountLink);
            MyAccountLink.Click();
            return GetInstance<SignInAtYourSidePage>(Driver);
        }
    }
}
