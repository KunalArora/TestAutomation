using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class CustomerActionsSteps : BaseSteps
    {
        [Then(@"I can navigate to the Activate Code page")]
        public void ThenICanNavigateToTheActivateCodePage()
        {
            CurrentDriver.Navigate().GoToUrl(CurrentDriver.Url + @"\omnijoin\activate");
        }


        [Then(@"I can activate the stored Activation code")]
        public void ThenICanActivateTheStoredActivationCode()
        {
            CurrentPage.As<CodeActivationPage>().EnterActivationCode(Helper.OrpActivationCode);
            NextPage = CurrentPage.As<CodeActivationPage>().ClickSubmitCodeButton();
        }

        [When(@"I navigate to Manage Plan")]
        public void WhenINavigateToManagePlan()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can see my OmniJoin plan")]
        public void ThenICanSeeMyOmniJoinPlan()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"I should see partner portal homepage without manageusers list page access")]
        public void ThenIShouldSeePartnerPortalHomepageWithoutManageusersListPageAccess()
        {
            CurrentPage.As<PartnerPortalPage>().IsHomeButtonDisplayed();
        }

    }
}
      
     