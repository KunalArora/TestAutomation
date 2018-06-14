using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.DealerAdmin
{
    [Binding]
    public class DealerAdminProfileSteps : BaseSteps
    {
        [When(@"I enter new profile into the profile box")]
        public void WhenIEnterNewProfileIntoTheProfileBox()
        {
            CurrentPage.As<DealerAdminProfileDealershipPage>().EnterDealershipProfile();
        }

        [When(@"I save the profile")]
        public void WhenISaveTheProfile()
        {
            CurrentPage.As<DealerAdminProfileDealershipPage>().SaveEnterDealerProfile();
        }

        [Then(@"the new profile is same as the recently entered profile")]
        public void ThenTheNewProfileIsSameAsTheRecentlyEnteredProfile()
        {
            CurrentPage.As<DealerAdminProfileDealershipPage>().VerifyThatProfileInputedIsSaved();
        }

        [Given(@"I navigate to Admin page")]
        [When(@"I navigate to Admin page")]
        public void WhenINavigateToAdminPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToAdminPage();
        }



    }
}
