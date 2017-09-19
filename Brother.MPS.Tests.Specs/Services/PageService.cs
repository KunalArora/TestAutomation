using System;
using System.Diagnostics;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Resolvers;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.Tests.Specs.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Services
{
    public class PageService : IPageService
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _context;
        private readonly IUrlResolver _urlResolver;

        public PageService(IWebDriver driver, 
            ScenarioContext context,
            IUrlResolver urlResolver)
        {
            _driver = driver;
            _context = context;
            _urlResolver = urlResolver;
        }

        #region Page loads

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string server = null)
        {
            var url = string.Format("{0}/sign-in", server ?? _urlResolver.AtYourSideUrl);
            LoadUrl(url, 10, "div.common-global-footer");
            return GetPageObject<SignInAtYourSidePage>(10);
        }

        #endregion

        public TPage GetPageObject<TPage>(int? timeout = null) where TPage : BasePage, IPageObject, new()
        {
            var pageObject = new TPage { Driver = _driver };
            string validationElementSelector = string.IsNullOrWhiteSpace(pageObject.ValidationElementSelector) ? "body" : pageObject.ValidationElementSelector;

            if (timeout != null)
            {
                var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds((int)timeout)).Until(d => d.FindElement(By.CssSelector(validationElementSelector)));
            }

            PageFactory.InitElements(_driver, pageObject);
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
            
            Console.WriteLine("PageService.LoadUrl: Starting load of url {0}", url);
            var runner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            _driver.Url = url;
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0)); //remove any implicit waits
            Helper.MsgOutput(string.Format("Load of url {0} started", url));
            try
            {
                var webDriverWait = new WebDriverWait(_driver, timeSpan).Until(d => d.FindElement(By.CssSelector(validationElementSelector)));
                Helper.MsgOutput(string.Format("Url {0} loaded - success indicated by presence of validation element {1}", url, validationElementSelector));
            }
            catch (Exception ex)
            {
                TestCheck.AssertFailTest(String.Format("Url {0} failed to load within {1} seconds (validation element {2} was not found){3}PAGE_NOT_LOADED", url, timeout.ToString(), validationElementSelector, MessageWithCategories.DefaultSeparator));
            }
        }

        public TPage LoadUrl<TPage>(string url, int timeout, string validationElementSelector = null, bool addToContextAsCurrentPage = false) where TPage : BasePage, IPageObject, new()
        {
            LoadUrl(url, timeout, validationElementSelector);
            var pageObject = GetPageObject<TPage>();

            if (addToContextAsCurrentPage)
            {
                _context.SetCurrentPage(pageObject);
            }

            return pageObject;
        }
    }
}
