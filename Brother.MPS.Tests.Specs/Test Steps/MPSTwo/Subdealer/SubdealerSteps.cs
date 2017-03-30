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


    }
}
