﻿using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages8._0.BrotherMainSite;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.BrotherMainSite.FooterNavigation
{
   
    public class NavigateFooterWebsiteInformationMenuSteps : BaseSteps
    {
       
        [Given(@"I have clicked the privacy policy link in the footer section")]
        public void GivenIHaveClickedThePrivacyPolicyLinkInTheFooterSection()
        {
            ScenarioContext.Current.Pending();
        }
        [Given(@"I have clicked the accessibility link in the footer section")]
        public void GivenIHaveClickedTheAccessibilityLinkInTheFooterSection()
        {
            CurrentPage.As<FooterNavigationPage>().HoverAndClickBrotherNetwork();
        }
        [Given(@"I have clicked the terms and conditions link in the footer section")]
        public void GivenIHaveClickedTheTermsAndConditionsLinkInTheFooterSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the accessibility page")]
        public void ThenIAmNavigatedToTheAccessibilityPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the privacy policy page")]
        public void ThenIAmNavigatedToThePrivacyPolicyPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the terms and conditions page")]
        public void ThenIAmNavigatedToTheTermsAndConditionsPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I am navigated to the brother network page")]
        public void ThenIAmNavigatedToTheBrotherNetworkPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
