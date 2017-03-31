using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Subdealer
{
    [Binding]
    public class SubdealerSteps : BaseSteps
    {
        [When(@"I navigate to Dealership Users page")]
        [Given(@"I navigate to Dealership Users page")]
        public void GivenINavigateToDealershipUsersPage()
        {
            NextPage = CurrentPage.As<DealerAdminDashBoardPage>().NavigateToDealerAdminDealershipUsersPage();

        }

        [Then(@"the list of existing subdealer is displayed")]
        public void ThenTheListOfExistingSubdealerIsDisplayed()
        {
            CurrentPage.As<DealerAdminDealershipUsersPage>().IsDealershipUserPageDisplayed();
        }

        [When(@"I begin subdealer creation process")]
        public void WhenIBeginSubdealerCreationProcess()
        {
            NextPage = CurrentPage.As<DealerAdminDealershipUsersPage>().StartSubDealerCreation();
        }

        [When(@"I enter all details with ""(.*)"" as the permission")]
        public void WhenIEnterAllDetailsWithAsThePermission(string permission)
        {
            CurrentPage.As<DealerAdminDealershipUsersCreationPage>().FillSubDealerDetails(permission);
        }

        [When(@"I submit the detail for creation")]
        public void WhenISubmitTheDetailForCreation()
        {
            NextPage = CurrentPage.As<DealerAdminDealershipUsersCreationPage>().SaveSubdealerDetails();
        }

        [Then(@"the subdealer created is shown on the list of subdealers")]
        public void ThenTheSubdealerCreatedIsShownOnTheListOfSubdealers()
        {
            CurrentPage.As<DealerAdminDealershipUsersPage>().IsSubdealerCreated();
        }



    }
}
