using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
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
using System.Collections.Generic;
using System.Globalization;
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
        private IWebDriver _bankWebDriver;
        private IWebDriver _loFinanceWebDriver;
        private IWebDriver _subDealerWebDriver;
        private IWebDriver _bieAdminWebDriver;
        private IContextData _contextData;

        private readonly Dictionary<UserType, string> DashBoardUrl = new Dictionary<UserType, string>()
        {
            { UserType.Dealer,                  "/mps/dealer/dashboard" },
            { UserType.LocalOfficeApprover,     "/mps/local-office/dashboard" },
            { UserType.Customer,                "/mps/customer/dashboard" },
            { UserType.LocalOfficeSupportDesk,  "/mps/local-office/dashboard" },
            { UserType.LocalOfficeAdmin,        "/mps/local-office/dashboard" },
            { UserType.Bank,                    "/mps/bank/dashboard" },
            { UserType.LocalOfficeFinance,      "/mps/local-office/finance/dashboard" },
            { UserType.SubDealer,               "/mps/dealer/dashboard" },
            { UserType.BIEAdmin,                "/mps/bie-admin/dashboard" },
        };

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
            var dealerDashboardUrl = DashBoardUrl[UserType.Dealer];
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            if (_dealerWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                if (_contextData.Environment == "PROD" && _contextData.Country.AtYourSideEnabled)
                {
                    var signInPage = LoadAtYourSideSignInPage(url, _dealerWebDriver);
                    return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, string.Format("{0}{1}", UrlResolver.BaseUrl, dealerDashboardUrl), _dealerWebDriver);
                }
                else
                {
                    var signInPage = LoadBrotherOnlineSignInPage(url, _dealerWebDriver);
                    return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, _dealerWebDriver);
                }
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
            return SignInAs<LocalOfficeApproverDashBoardPage>(email, password, url, UserType.LocalOfficeApprover, out _loApproverWebDriver);
        }

        public ServiceDeskDashBoardPage SignInAsServiceDesk(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return SignInAs<ServiceDeskDashBoardPage>(email, password, url, UserType.LocalOfficeSupportDesk, out _serviceDeskWebDriver);
        }

        public LocalOfficeAdminDashBoardPage SignInAsLocalOfficeAdmin(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return SignInAs<LocalOfficeAdminDashBoardPage>(email, password, url, UserType.LocalOfficeAdmin, out _loAdminWebDriver);
        }

        public CustomerDashBoardPage SignInAsCustomer(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            var customerDashboardUrl = DashBoardUrl[UserType.Customer];
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

        public BankDashBoardPage SignInAsBank(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return SignInAs<BankDashBoardPage>(email, password, url, UserType.Bank, out _bankWebDriver);
        }

        public LocalOfficeFinanceDashBoardPage SignInAsFinance(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return SignInAs<LocalOfficeFinanceDashBoardPage>(email, password, url, UserType.LocalOfficeFinance, out _loFinanceWebDriver);
        }

        public BieAdminDashboardPage SignInAsBieAdmin(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return SignInAs<BieAdminDashboardPage>(email, password, url, UserType.BIEAdmin, out _bieAdminWebDriver);
        }

        private TPage SignInAs<TPage>(string email, string password, string url, UserType userType, out IWebDriver webDriver) where TPage : BasePage, IPageObject, new()
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url, userType);
            webDriver = WebDriverFactory.GetWebDriverInstance(userType);
            webDriver.SwitchTo().Window(_contextData.WindowHandles[userType]);
            var dashboardUrl = DashBoardUrl[userType];
            if (webDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                if (_contextData.Environment == "PROD" && _contextData.Country.AtYourSideEnabled)
                {
                    var signInPage = LoadAtYourSideSignInPage(url, webDriver);
                    return SignInToMpsDashboardAs<TPage>(signInPage, email, password, string.Format("{0}{1}", UrlResolver.BaseUrl, dashboardUrl), webDriver);
                }
                else
                {
                    var signInPage = LoadBrotherOnlineSignInPage(url, webDriver);
                    return SignInToMpsDashboardAs<TPage>(signInPage, email, password, webDriver);
                }
            }
            else
            {
                var uri = new Uri(webDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, DashBoardUrl[userType]);
                return PageService.LoadUrl<TPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, webDriver);
            }
        }

        public DealerDashBoardPage SignInAsSubDealer(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            var dealerDashboardUrl = DashBoardUrl[UserType.SubDealer];
            _subDealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.SubDealer);
            _contextData.DriverInstance = UserType.SubDealer;
            if (_subDealerWebDriver.Manage().Cookies.GetCookieNamed(".ASPXAUTH") == null)
            {
                if (_contextData.Environment == "PROD" && _contextData.Country.AtYourSideEnabled)
                {
                    var signInPage = LoadAtYourSideSignInPage(url, _subDealerWebDriver);
                    return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, string.Format("{0}/{1}", UrlResolver.BaseUrl, dealerDashboardUrl), _subDealerWebDriver);
                }
                else
                {
                    var signInPage = LoadBrotherOnlineSignInPage(url, _subDealerWebDriver);
                    return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, _subDealerWebDriver);
                }
            }
            else
            {
                var uri = new Uri(_subDealerWebDriver.Url);
                var dashBoardUri = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, dealerDashboardUrl);
                return PageService.LoadUrl<DealerDashBoardPage>(dashBoardUri, RuntimeSettings.DefaultPageLoadTimeout, "div.mps-dashboard", true, _subDealerWebDriver);
            }
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url, IWebDriver driver, bool acceptCookiePolicy = true)
        {
            LoggingService.WriteLogOnMethodEntry(url, driver);
            var signInPage = PageService.LoadAtYourSideSignInPage(driver);
            ScenarioContext.SetCurrentPage(signInPage);

            if (acceptCookiePolicy)
            {
                var cookie = driver.Manage().Cookies.GetCookieNamed("allowCookies");

                if (cookie == null || cookie.Value.ToLower() != "yes")
                {
                    var seleniumHelper = new SeleniumHelper(driver, LoggingService, RuntimeSettings);
                    var acceptButton = seleniumHelper.FindElementByCssSelector("#AcceptCookieLawHyperLink", -1);
                
                    acceptButton.Click();
                }
            }

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

        public void SetCultureInfoAndRegionInfo()
        {
            LoggingService.WriteLogOnMethodEntry();

            _contextData.CultureInfo = new CultureInfo(_contextData.Culture);
            _contextData.RegionInfo = new RegionInfo(_contextData.Culture);

            switch (_contextData.Country.CountryIso)
            {
                case CountryIso.Switzerland:
                    // This is done as currency symbol for Switzerland set in culture settings of Windows 7 & Windows 10 are different
                    _contextData.CultureInfo.NumberFormat.CurrencySymbol = MpsUtil.GetCurrencySymbol(_contextData.Country.CountryIso);

                    // This is done as decimal separator for Switzerland set in culture settings of Windows 7 & Windows 10 are different
                    _contextData.CultureInfo.NumberFormat.NumberDecimalSeparator = ".";

                    _contextData.CultureInfo.NumberFormat.CurrencyGroupSeparator = "'";
                    _contextData.CultureInfo.NumberFormat.CurrencyPositivePattern = 2; // "$ n"
                    break;

                case CountryIso.Denmark:
                    _contextData.CultureInfo.NumberFormat.CurrencyPositivePattern = 2; // "$ n"
                    break;

                default:
                    break;
            }
        }
    }
}
