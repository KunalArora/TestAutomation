﻿using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    //[Binding]
    public class MpsSignInSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;

        public MpsSignInSteps(ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
        }

        public SignInAtYourSidePage SignInPage { get; set; }
        public MyAccountAtYourSidePage MyAccountPage { get; set; }

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
            if (server != null) _context.Add("ContextBaseUrl", server);
            SignInPage = _pageService.LoadAtYourSideSignInPage();
            _context.SetCurrentPage(SignInPage);
            SignInPage.IsSignInButtonAvailable();
        }

        //[When(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[When(@"I return to Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[When(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[Then(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[Then(@"I sign into MPS as a ""(.*)"" from ""(.*)""")]
        //[Then(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[Given(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[Given(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        //[Given(@"I sign into MPS as a ""(.*)"" from ""(.*)""")]
        //public void GivenISignIntoMpsasAFrom(string role, string country)
        //{
        //    if (Helper.CountryIsUsingAtYourSideLogin(country))
        //    {
        //        Helper.SetCountry(country);
        //        Given(string.Format(@"I sign into Cloud MPS bypassing the home page as a ""{0}"" from ""{1}""", role, country));
        //        WhenISignInAsA(role, country);
        //        return;
        //    }

        //    GivenILaunchBrotherOnlineFor(country);
        //    WhenIClickOnSignInCreateAnAccount(country);
        //    WhenISignInAsA(role, country);

        //}
    }
}
