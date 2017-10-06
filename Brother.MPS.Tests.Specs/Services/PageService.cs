using System;
using System.Diagnostics;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.Tests.Specs.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using SeleniumHelper = Brother.Tests.Selenium.Lib.Helpers.SeleniumHelper;

namespace Brother.Tests.Specs.Services
{
    public class PageService : IPageService
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _context;
        private readonly IUrlResolver _urlResolver;
        private readonly ISeleniumHelper _seleniumHelper;

        public PageService(IWebDriver driver, 
            ScenarioContext context,
            IUrlResolver urlResolver,
            ISeleniumHelper seleniumHelper)
        {
            _driver = driver;
            _context = context;
            _urlResolver = urlResolver;
            _seleniumHelper = seleniumHelper;
        }

        #region Page loads

        public SignInAtYourSidePage LoadAtYourSideSignInPage(IWebDriver driver = null, string server = null)
        {
            var url = string.Format("{0}/sign-in", server ?? _urlResolver.AtYourSideUrl);
            LoadUrl(url, 10, "footer.common-global-footer", driver);
            return GetPageObject<SignInAtYourSidePage>(10, driver);
        }

        #endregion

        public TPage GetPageObject<TPage>(int? timeout = null, IWebDriver driver = null) where TPage : BasePage, IPageObject, new()
        {
            if (driver == null)
            {
                driver = _driver;
            }

            var pageObject = new TPage { Driver = driver, SeleniumHelper = new SeleniumHelper(driver) };
            string validationElementSelector = string.IsNullOrWhiteSpace(pageObject.ValidationElementSelector) ? "body" : pageObject.ValidationElementSelector;

            if (timeout != null)
            {
                var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds((int)timeout)).Until(d => d.FindElement(By.CssSelector(validationElementSelector)));
            }

            PageFactory.InitElements(driver, pageObject);
            return pageObject;
        }

        /// <summary>
        /// Load a url within the specified timeout, optionally validating that the page includes a given element
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <param name="validationElementSelector"></param>
        /// <param name="driver">Override the injected driver with a specific instance</param>
        public void LoadUrl(string url, int timeout, string validationElementSelector = null, IWebDriver driver = null)
        {
            var timeSpan = TimeSpan.FromSeconds(timeout);

            if (string.IsNullOrWhiteSpace(validationElementSelector))
            {
                validationElementSelector = "body";
            }

            if (driver == null)
            {
                driver = _driver;
            }

            Console.WriteLine("PageService.LoadUrl: Starting load of url {0}", url);
            var runner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            driver.Url = url;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0)); //remove any implicit waits
            Helper.MsgOutput(string.Format("Load of url {0} started", url));
            try
            {
                var webDriverWait = new WebDriverWait(driver, timeSpan).Until(d => d.FindElement(By.CssSelector(validationElementSelector)));
                Helper.MsgOutput(string.Format("Url {0} loaded - success indicated by presence of validation element {1}", url, validationElementSelector));
            }
            catch (Exception ex)
            {
                TestCheck.AssertFailTest(String.Format("Url {0} failed to load within {1} seconds (validation element {2} was not found){3}PAGE_NOT_LOADED", url, timeout.ToString(), validationElementSelector, MessageWithCategories.DefaultSeparator));
            }
        }

        public TPage LoadUrl<TPage>(string url, int timeout, string validationElementSelector = null, bool addToContextAsCurrentPage = false, IWebDriver driver = null) where TPage : BasePage, IPageObject, new()
        {
            LoadUrl(url, timeout, validationElementSelector, driver);
            var pageObject = GetPageObject<TPage>(timeout, driver);

            if (addToContextAsCurrentPage)
            {
                _context.SetCurrentPage(pageObject);
            }

            return pageObject;
        }
    }
}
