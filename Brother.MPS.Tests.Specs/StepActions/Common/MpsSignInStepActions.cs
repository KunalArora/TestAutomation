using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer;
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
        private IWebDriver _serviceDeskWebDriver;
        private IWebDriver _loAdminWebDriver;
        private IContextData _contextData;

        private const string dealerDashboardUrl = "/mps/dealer/dashboard";
        private const string loApproverDashboardUrl = "/mps/local-office/dashboard";
        private const string customerDashboardUrl = "/mps/customer/dashboard";
        private const string serviceDeskDashboardUrl = "/mps/local-office/dashboard";
        private const string loAdminDashboardUrl = "/mps/local-office/dashboard";


        public MpsSignInStepActions (
            IWebDriver driver,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings) : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
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
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _loApproverWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.LocalOfficeApprover]);
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

        public ServiceDeskDashBoardPage SignInAsServiceDesk(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            _serviceDeskWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeSupportDesk);
            _serviceDeskWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.LocalOfficeSupportDesk]);
            if (_serviceDeskWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                var signInPage = LoadBrotherOnlineSignInPage(url, _serviceDeskWebDriver);
                return SignInToMpsDashboardAs<ServiceDeskDashBoardPage>(signInPage, email, password, _serviceDeskWebDriver);
            }
            else
            {
                var uri = new Uri(_serviceDeskWebDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, serviceDeskDashboardUrl);
                return PageService.LoadUrl<ServiceDeskDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _serviceDeskWebDriver);
            }
        }

        public LocalOfficeAdminDashBoardPage SignInAsLocalOfficeAdmin(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            _loAdminWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeAdmin);
            _loAdminWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.LocalOfficeAdmin]);
            if (_loAdminWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                var signInPage = LoadBrotherOnlineSignInPage(url, _loAdminWebDriver);
                return SignInToMpsDashboardAs<LocalOfficeAdminDashBoardPage>(signInPage, email, password, _loAdminWebDriver);
            }
            else
            {
                var uri = new Uri(_loAdminWebDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, loAdminDashboardUrl);
                return PageService.LoadUrl<LocalOfficeAdminDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _loAdminWebDriver);
            }
        }

        public CustomerDashBoardPage SignInAsCustomer(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
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
            LoggingService.WriteLogOnMethodEntry(url, driver);
            var signInPage = PageService.LoadAtYourSideSignInPage(driver);
            ScenarioContext.SetCurrentPage(signInPage);
            return signInPage;
        }

        public RegistrationPage LoadBrotherOnlineSignInPage(string url, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(url, driver);
            var registrationPage = new RegistrationPage();
            registrationPage = PageService.LoadUrl<RegistrationPage>(url, RuntimeSettings.DefaultPageLoadTimeout, registrationPage.ValidationElementSelector, true, driver);
            return registrationPage;
        }

        private TPage SignInToMpsDashboardAs<TPage>(RegistrationPage registrationPage, string email, string password, IWebDriver driver) where TPage : BasePage, IPageObject, new()
        {
            LoggingService.WriteLogOnMethodEntry(registrationPage, email, password, driver);
            registrationPage.PopulateEmailAddressTextBox(email);
            registrationPage.PopulatePassword(password);
            registrationPage.ScrollTo(registrationPage.SignInButton);
            registrationPage.SignInButton.Click();
            return PageService.GetPageObject<TPage>(RuntimeSettings.DefaultPageObjectTimeout, driver);
        }

        private TPage SignInToMpsDashboardAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password, string dashboardUrl, IWebDriver driver) where TPage : BasePage, IPageObject, new()
        {
            LoggingService.WriteLogOnMethodEntry(signInAtYourSidePage, email, password, dashboardUrl, driver);
            signInAtYourSidePage.PopulateEmailAddressTextBox(email);
            signInAtYourSidePage.PopulatePassword(password);
            signInAtYourSidePage.SignInButton.Click();
            var myAccountPage = PageService.GetPageObject<MyAccountAtYourSidePage>(RuntimeSettings.DefaultPageObjectTimeout, driver);
            return PageService.LoadUrl<TPage>(dashboardUrl, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, driver);
        }

        public InstallerContractReferenceInstallationPage LoadInstallationPage(string url)
        {
            LoggingService.WriteLogOnMethodEntry(url);
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            var installationPage = new InstallerContractReferenceInstallationPage();
            installationPage = PageService.LoadUrl<InstallerContractReferenceInstallationPage>(url, RuntimeSettings.DefaultPageLoadTimeout, installationPage.ValidationElementSelector, true, _installerWebDriver);
            return installationPage;
        }

        public InstallationSelectMethodPage LoadInstallationSelectMethodPageType3(string url)
        {
            LoggingService.WriteLogOnMethodEntry(url);
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            var installationPage = new InstallationSelectMethodPage();
            installationPage = PageService.LoadUrl<InstallationSelectMethodPage>(url, RuntimeSettings.DefaultPageLoadTimeout, installationPage.ValidationElementSelector, true, _installerWebDriver);
            return installationPage;
        }

        public InstallationManageInstallationsPage LoadInstallationManageInstallationsPageType3(string url)
        {
            LoggingService.WriteLogOnMethodEntry(url);
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            var installationPage = new InstallationManageInstallationsPage();
            installationPage = PageService.LoadUrl<InstallationManageInstallationsPage>(url, RuntimeSettings.DefaultPageLoadTimeout, installationPage.ValidationElementSelector, true, _installerWebDriver);
            return installationPage;
        }
    }
}
