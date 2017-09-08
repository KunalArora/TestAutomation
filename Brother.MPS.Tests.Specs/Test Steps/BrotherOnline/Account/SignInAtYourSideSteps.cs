using System;
using System.Collections.Generic;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow = Brother.Tests.Selenium.Lib.Support.HelperClasses.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    //[Binding]
    public class SignInAtYourSideSteps : BaseSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;

        public SignInAtYourSideSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"I sign into Cloud MPS bypassing the home page as a ""(.*)"" from ""(.*)""")]
        public void GivenISignIntoMpsBypassingTheHomePageAsRoleFromCountry(string role, string country)
        {
            GivenILaunchAtYourSideSignInPage(country, null);
        }

        [Given(@"I sign into Cloud MPS using the At Your Side journey as a ""(.*)"" from ""(.*)"" on server ""(.*)""")]
        public void GivenISignIntoMpsBypassingTheHomePageAsRoleFromCountry(string role, string country, string server)
        {
            GivenILaunchAtYourSideSignInPage(country, server);
        }

        [Given(@"I launch the At Your Side sign in page for ""(.*)""")]
        [Given(@"I launch the At Your Side sign in page for ""(.*)"" on server ""(.*)""")]
        public void GivenILaunchAtYourSideSignInPage(string country, string server = null)
        {
            //BasePage.LoadAtYourSideSignInPage(CurrentDriver);
            //_context.Add(SUBJECT_PAGE_KEY, BasePage.LoadAtYourSideSignInPage(CurrentDriver));
            //var current = _context.Get<RegistrationPage>(SUBJECT_PAGE_KEY);
            if(server != null) _context.Add("ContextBaseUrl", server);
            CurrentPage = BasePage.LoadAtYourSideSignInPage(CurrentDriver, server);
            GetSubjectPage<SignInAtYourSidePage>().IsSignInButtonAvailable();
        }

    }
}
