using System;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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
            //_driver.Navigate().GoToUrl(server == null ? AtYourSideSignInUrl : server + "/sign-in");
            //NavigateToPage(driver, server == null ? AtyoursideSignInUrl : server + "/sign-in");
            try
            {
                LoadUrl(server == null ? AtYourSideSignInUrl : server + "/sign-in", 10, "#jeff");
            }
            catch (Exception ex)
            {
                TestCheck.AssertFailTest(String.Format("Url {0} failed to load within {1} seconds (validation element {2} was not found){3}PAGE_NOT_LOADED", "/sign-in", "10", "#jeff", MessageWithCategories.DefaultSeparator));
            }
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

        /// <summary>
        /// Load a url within the specified timeout, optionally validating that the page includes a given element
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <param name="validationElementSelector"></param>
        public void LoadUrl(string url, int timeout, string validationElementSelector = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);

            if (string.IsNullOrWhiteSpace(validationElementSelector))
            {
                validationElementSelector = "body";
            }

            _driver.Url = url;
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0)); //remove any implicit waits
            try
            {
                var webDriverWait = new WebDriverWait(_driver, timeSpan).Until(d => d.FindElement(By.CssSelector(validationElementSelector)));
            }
            catch (Exception ex)
            {
                TestCheck.AssertFailTest(String.Format("Url {0} failed to load within {1} seconds (validation element {2} was not found){3}PAGE_NOT_LOADED", url, timeout.ToString(), validationElementSelector, MessageWithCategories.DefaultSeparator));
            }
        }
    }
}
