using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages8._0.BrotherMainSite;
using TechTalk.SpecFlow;
using MainSiteHomePage = Brother.WebSites.Core.Pages.BrotherMainSite.MainSiteHomePage;


namespace Brother.Tests.Specs._80.BrotherMainSite.FooterNavigation
{
    [Binding]
    public class NavigateFooterWebsiteInformationMenuSteps : BaseSteps
    {
       
        [Given(@"I have clicked the privacy policy link in the footer section")]
        public void GivenIHaveClickedThePrivacyPolicyLinkInTheFooterSection()
        {
            ScenarioContext.Current.Pending();
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
            CurrentPage.As<FooterNavigationPage>().CheckPageExist();
        }
        [Given(@"I have clicked the brother network link in the footer section")]
        public void GivenIHaveClickedTheBrotherNetworkLinkInTheFooterSection()
        {
            //CurrentPage.As<MainSiteHomePage>().HoverAndClickBrotherNetwork();
            CurrentPage.As<FooterNavigationPage>().HoverAndClickBrotherNetwork();
        }
    }

        
    }

