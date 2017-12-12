using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsSignInStepActions : StepActionBase
    {
        private IWebDriver _dealerWebDriver;
        private IWebDriver _installerWebDriver;
        private IWebDriver _loApproverWebDriver;
        private IWebDriver _customerWebDriver;

        private const string dealerDashboardUrl = "/mps/dealer/dashboard";
        private const string loApproverDashboardUrl = "/mps/local-office/dashboard";
        private const string customerDashboardUrl = "/mps/customer/dashboard";

        public MpsSignInStepActions (IWebDriver driver,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings) : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            if (_dealerWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                var signInPage = LoadBrotherOnlineSignInPage(url, _dealerWebDriver);
                return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, _dealerWebDriver);
            }
            else
            {
                var uri = new Uri(_dealerWebDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, dealerDashboardUrl);
                return PageService.LoadUrl<DealerDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _dealerWebDriver);
            }
        }

        public LocalOfficeApproverDashBoardPage SignInAsLocalOfficeApprover(string email, string password, string url)
        {
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            if (_loApproverWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                var signInPage = LoadBrotherOnlineSignInPage(url, _loApproverWebDriver);
                return SignInToMpsDashboardAs<LocalOfficeApproverDashBoardPage>(signInPage, email, password, _loApproverWebDriver);
            }
            else
            {
                var uri = new Uri(_loApproverWebDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, loApproverDashboardUrl);
                return PageService.LoadUrl<LocalOfficeApproverDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _loApproverWebDriver);
            }
        }

        public CustomerDashBoardPage SignInAsCustomer(string email, string password, string url)
        {   
            _customerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Customer);
            if (_customerWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                var signInPage = LoadBrotherOnlineSignInPage(url, _customerWebDriver);
                SignInToMpsDashboardAs<CustomerRootPage>(signInPage, email, password, _customerWebDriver);
            }
            var uri = new Uri(_customerWebDriver.Url);
            var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, customerDashboardUrl);
            return PageService.LoadUrl<CustomerDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _customerWebDriver);
            
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url, IWebDriver driver)
        {
            var signInPage = PageService.LoadAtYourSideSignInPage(driver);
            ScenarioContext.SetCurrentPage(signInPage);
            return signInPage;
        }

        public RegistrationPage LoadBrotherOnlineSignInPage(string url, IWebDriver driver)
        {
            var registrationPage = new RegistrationPage();
            registrationPage = PageService.LoadUrl<RegistrationPage>(url, RuntimeSettings.DefaultPageLoadTimeout, registrationPage.ValidationElementSelector, true, driver);
            return registrationPage;
        }

        private TPage SignInToMpsDashboardAs<TPage>(RegistrationPage registrationPage, string email, string password, IWebDriver driver) where TPage : BasePage, IPageObject, new()
        {
            registrationPage.PopulateEmailAddressTextBox(email);
            registrationPage.PopulatePassword(password);
            registrationPage.ScrollTo(registrationPage.SignInButton);
            registrationPage.SignInButton.Click();
            return PageService.GetPageObject<TPage>(RuntimeSettings.DefaultPageObjectTimeout, driver);
        }

        private TPage SignInToMpsDashboardAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password, string dashboardUrl, IWebDriver driver) where TPage : BasePage, IPageObject, new()
        {
            signInAtYourSidePage.PopulateEmailAddressTextBox(email);
            signInAtYourSidePage.PopulatePassword(password);
            signInAtYourSidePage.SignInButton.Click();
            var myAccountPage = PageService.GetPageObject<MyAccountAtYourSidePage>(RuntimeSettings.DefaultPageObjectTimeout, driver);
            return PageService.LoadUrl<TPage>(dashboardUrl, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, driver);
        }

        public InstallerContractReferenceInstallationPage LoadInstallationPage(string url)
        {
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            var installationPage = new InstallerContractReferenceInstallationPage();
            installationPage = PageService.LoadUrl<InstallerContractReferenceInstallationPage>(url, RuntimeSettings.DefaultPageLoadTimeout, installationPage.ValidationElementSelector, true, _installerWebDriver);
            return installationPage;
        }
    }
}
