
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Net;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs._80.Test_Steps.BrotherMainSite.PublishedPages
{
    [Binding]
    public class PublishedPagesSteps : BaseSteps
    {
        [Given(@"I have navigated to the published url ""(.*)""")]
        public void GivenIHaveNavigatedToTheUrl(string p0)
        {
            CurrentDriver.Navigate().GoToUrl(p0);
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
        }

        [Given(@"That I navigate to ""(.*)"" in order to validate a published page")]
        public void GivenThatINavigateToInOrderToValidateTheCmsSite(string url)
        {
            CurrentPage = BasePage.LoadPublishedPage(CurrentDriver, url);
            CurrentPage.As<PublishedPage>().GetPublishedPage(url);
        }

        [Then(@"I can verify that the page header is displayed")]
        public void ThenICanVerifyThatThePageHeaderIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsPageHeaderDisplayed();
        }

        [Then(@"I can verify that the search icon is displayed")]
        public void ThenICanVerifyThatTheSearchIconIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSearchIconDisplayed();
        }


    }

}

