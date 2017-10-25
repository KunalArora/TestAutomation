using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsSignInStepActions : StepActionBase
    {
        private IWebDriver _dealerWebDriver;
        private IWebDriver _loApproverWebDriver;

        public MpsSignInStepActions (IWebDriver driver,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            RuntimeSettings runtimeSettings) : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            var signInPage = LoadBrotherOnlineSignInPage(url, _dealerWebDriver);
            return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, _dealerWebDriver);
        }

        public LocalOfficeApproverDashBoardPage SignInAsLocalOfficeApprover(string email, string password, string url)
        {
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            var signInPage = LoadBrotherOnlineSignInPage(url, _loApproverWebDriver);
            return SignInToMpsDashboardAs<LocalOfficeApproverDashBoardPage>(signInPage, email, password, _loApproverWebDriver);
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
    }
}
