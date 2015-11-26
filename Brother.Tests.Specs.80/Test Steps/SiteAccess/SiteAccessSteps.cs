﻿using System;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages8._0.CMS;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs._80.SiteAccess
{
    [Binding]
    public class SiteAccessSteps : BaseSteps
    {
        [Given(@"The following site ""(.*)"" to validate I should receive an Ok response back\ton mainsite")]
        public void GivenTheFollowingSiteToValidateIShouldReceiveAnOkResponseBackOnMainsite(string url)
        {
            // Perform a page GET
            TestCheck.AssertIsEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code returned");

            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));

            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        [Given(@"The following site test site ""(.*)"" to validate I should receive an Ok response back")]
        public void GivenTheFollowingSiteTestSiteToValidateIShouldReceiveAnOkResponseBack(string url)
        {
            // Perform a page GET
            TestCheck.AssertIsEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code returned");

            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));

            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        [Given(@"The following site (.*) (.*) to validate I should receive an Ok response back")]
        public void GivenTheFollowingSiteToValidateIShouldReceiveAnOkResponseBack(string country, string url)
        {
            const int maxTries = 5;
            var responseCode = HttpStatusCode.Ambiguous;

            Helper.MsgOutput(string.Format("Navigating to  [{0}] Main Site", country));
            for (var attempts = 1; attempts < maxTries; attempts++)
            {
                Helper.MsgOutput(string.Format("Website response attempt number [{0}]", attempts));

                // Perform a page GET
                responseCode = GetWebPageResponse(url);
                switch (responseCode)
                {
                    case HttpStatusCode.Found:
                    case HttpStatusCode.OK:
                        attempts = 5;
                        WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
                        //WebSites.Core.Pages.General.SiteAccess.ValidateLiveSiteUrl(url);
                        WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
                        break;
                    case HttpStatusCode.MultipleChoices:
                        Helper.MsgOutput("Response code was Multiple Choices - retrying using relocate URL");
                        break;
                    default:
                        Helper.MsgOutput(string.Format("Failed to get a response from [{0}] - retrying [{1}] times", url,
                            attempts));
                        break;
                }
            }

            TestCheck.AssertIsEqual(HttpStatusCode.OK, responseCode, "Http Status Code Returned");
            WebDriver.Wait(Helper.DurationType.Second, 2); // small pause between each site check
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));

            return responseCode;
        }


        [When(@"I have entered a valid username and password, ""(.*)"", ""(.*)""")]
        public void WhenIHaveEnteredAValidUsernameAndPassword(string username, string password)
        {
            CurrentPage.As<CmsHomepage>().PopulateFirstNameTextBox(username);
            CurrentPage.As<CmsHomepage>().PopulateLastNameTextBox(password);            
        }

    }


                   
}