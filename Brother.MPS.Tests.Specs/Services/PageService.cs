using System;
using System.Threading;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Specs.Services
{
    public class PageService : IPageService
    {
        private readonly IWebDriver _driver;
        private const string AtYourSideSignInUrl = "https://atyourside.co.uk.cds.uat.brother.eu.com/sign-in";

        public PageService(IWebDriver driver)
        {
            _driver = driver;
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string server = null)
        {
            _driver.Navigate().GoToUrl(server == null ? AtYourSideSignInUrl : server + "/sign-in");
            //NavigateToPage(driver, server == null ? AtyoursideSignInUrl : server + "/sign-in");
            return GetPageObject<SignInAtYourSidePage>();
            //return BasePage.GetInstance<SignInAtYourSidePage>(_driver, AtYourSideSignInUrl, "Sign in");
        }

        public TPage GetPageObject<TPage>() where TPage : BasePage, new()
        {
            var pageObject = new TPage { Driver = _driver };
            var timeSpan = TimeSpan.FromSeconds(60);

            //new WebDriverWait(_driver, timeSpan).Until(d => d.FindElement(By.TagName("body")));

            PageFactory.InitElements(_driver, pageObject);
            //Thread.Sleep(TimeSpan.FromSeconds(6));
            return pageObject;
        }
    }
}
