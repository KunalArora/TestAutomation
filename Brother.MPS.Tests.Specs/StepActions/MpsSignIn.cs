﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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

namespace Brother.Tests.Specs.StepActions
{
    public class MpsSignIn : StepActionBase
    {
        private readonly IWebDriver _dealerWebDriver;
        private readonly IWebDriver _loApproverWebDriver;

        public MpsSignIn (IWebDriver driver,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver) : base(driver, webDriverFactory, contextData, pageService, context, urlResolver)
        {
            _dealerWebDriver = webDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _loApproverWebDriver = webDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            var signInPage = LoadAtYourSideSignInPage(url, _dealerWebDriver);
            return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, string.Format("{0}/mps/dealer/dashboard", UrlResolver.BaseUrl), _dealerWebDriver);
        }

        public void SignInAsLocalOfficeApprover(string email, string password, string url)
        {
            var signInPage = LoadAtYourSideSignInPage(url, _loApproverWebDriver);
            SignInToMpsDashboardAs<LocalOfficeApproverDashBoardPage>(signInPage, email, password, string.Format("{0}/mps/local-office/dashboard", UrlResolver.BaseUrl), _loApproverWebDriver);
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url, IWebDriver driver)
        {
            var signInPage = PageService.LoadAtYourSideSignInPage(driver);
            ScenarioContext.SetCurrentPage(signInPage);
            return signInPage;
        }

        private TPage SignInToMpsDashboardAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password, string dashboardUrl, IWebDriver driver) where TPage : BasePage, IPageObject, new()
        {
            //TODO: form dashboard url from context data base url and TPage.url
            signInAtYourSidePage.PopulateEmailAddressTextBox(email);
            signInAtYourSidePage.PopulatePassword(password);
            signInAtYourSidePage.SignInButton.Click();
            var myAccountPage = PageService.GetPageObject<MyAccountAtYourSidePage>(10, driver);
            Helper.TakeSnapshot("Just trying it");
            Helper.SavePageSource();
            return PageService.LoadUrl<TPage>(dashboardUrl, 10, "div.mps-dashboard", true, driver);
        }
    }
}
