using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.DealerAdmin
{
    [Binding]
    public class DealerAdminProfileSteps : BaseSteps
    {
        [When(@"I enter new profile into the profile box")]
        public void WhenIEnterNewProfileIntoTheProfileBox()
        {
            CurrentPage.As<DealerAdminDealershipProfilePage>().EnterDealershipProfile();
        }

        [When(@"I save the profile")]
        public void WhenISaveTheProfile()
        {
            CurrentPage.As<DealerAdminDealershipProfilePage>().SaveEnterDealerProfile();
        }

        [Then(@"the new profile is same as the recently entered profile")]
        public void ThenTheNewProfileIsSameAsTheRecentlyEnteredProfile()
        {
            CurrentPage.As<DealerAdminDealershipProfilePage>().VerifyThatProfileInputedIsSaved();
        }

        [Given(@"I navigate to Admin page")]
        [When(@"I navigate to Admin page")]
        public void WhenINavigateToAdminPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToAdminPage();
        }



    }
}
