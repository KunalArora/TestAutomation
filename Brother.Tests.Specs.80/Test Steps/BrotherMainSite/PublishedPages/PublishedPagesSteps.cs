﻿
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

        [Then(@"I can verify that the top navigation component is displayed")]
        public void ThenICanVerifyThatTheTopNavigationComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsTopNavDisplayed();
        }

        [Then(@"I can verify that the accordion compoment is displayed")]
        public void ThenICanVerifyThatTheAccordionCompomentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsAccordionDisplayed();
        }

        [Then(@"I can verify that the features carousel component is displayed")]
        public void ThenICanVerifyThatTheFeaturesCarouselComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeaturesCarouselDisplayed();
        }

        [Then(@"I can verify that a features carousel tile is displayed")]
        public void ThenICanVerifyThatAFeaturesCarouselTileIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsFeaturesCarouselTileDisplayed();
        }

        [Then(@"I can verify that a banner bar component is displayed")]
        public void ThenICanVerifyThatABannerBarComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBannerBarDisplayedDisplayed();
        }

        [Then(@"I can verify that a banner bar tile is displayed")]
        public void ThenICanVerifyThatABannerBarTileIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsBannerBarTileDisplayed();
        }

        [Then(@"I can verify that an info image text module component is displayed")]
        public void ThenICanVerifyThatAnInforImageTextModuleComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsImageTextModuleDisplayed();
        }

        [Then(@"I can verify that the secondary navigation component is displayed")]
        public void ThenICanVerifyThatTheSecondaryNavigationComponentIsDisplayed()
        {
            CurrentPage.As<PublishedPage>().IsSecondaryNavigationDisplayed();
        }



    }

}

